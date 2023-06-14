using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.ApplicationServices.API.ErrorHandling;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Queries.Users;
using GameRev.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        private readonly IPasswordHasher<User> _passwordHasher;

        public UpdateUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery
            {
                Login = request.Login
            };

            var user = await _queryExecutor.Execute(query);

            if (user is null)
            {
                return new UpdateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            request.Password = _passwordHasher.HashPassword(user, request.Password);
            var mappedUser = _mapper.Map<User>(request);
            var command = new UpdateUserCommand()
            {
                Parameter = mappedUser
            };

            var updatedCommand = await _commandExecutor.Execute(command);

            return new UpdateUserResponse
            {
                Data = _mapper.Map<Domain.Models.User>(updatedCommand)
            };
        }
    }
}
