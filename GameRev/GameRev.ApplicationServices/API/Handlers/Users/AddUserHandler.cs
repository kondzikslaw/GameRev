using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.ApplicationServices.API.ErrorHandling;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Commands.Users;
using GameRev.DataAccess.CQRS.Queries.Users;
using GameRev.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class AddUserHandler : IRequestHandler<AddUsersRequest, AddUsersResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        private readonly IPasswordHasher<User> _passwordHasher;

        public AddUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<AddUsersResponse> Handle(AddUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Login = request.Login
            };

            var getUser = await _queryExecutor.Execute(query);

            if (getUser != null)
            {
                if (getUser.Login == request.Login)
                {
                    return new AddUsersResponse()
                    {
                        Error = new ErrorModel(ErrorType.ValidationError + "! This login is already taken.")
                    };
                }

                return new AddUsersResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            request.Password = _passwordHasher.HashPassword(getUser, request.Password);

            var user = _mapper.Map<User>(request);
            var command = new AddUserCommand() { Parameter = user };
            var userFromDb = await _commandExecutor.Execute(command);

            return new AddUsersResponse()
            {
                Data = _mapper.Map<Domain.Models.User>(userFromDb)
            };
        }
    }
}
