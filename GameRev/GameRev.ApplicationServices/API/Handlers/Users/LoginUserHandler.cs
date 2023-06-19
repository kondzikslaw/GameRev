using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.ErrorHandling;
using GameRev.DataAccess.CQRS.Commands.Users;
using GameRev.DataAccess.CQRS.Queries.Users;
using GameRev.DataAccess.CQRS;
using Microsoft.AspNetCore.Identity;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Login = request.Login
            };

            var getUser = await _queryExecutor.Execute(query);

            if (getUser == null)
            {
                return new LoginUserResponse()
                {
                    Error = new ErrorModel(ErrorType.InvalidIncomingData)
                };

            }

            var result = _passwordHasher.VerifyHashedPassword(getUser, getUser.Password, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return new LoginUserResponse()
                {
                    Error = new ErrorModel(ErrorType.InvalidIncomingData)
                };
            }

            var mappedUser = _mapper.Map<Domain.Models.User>(getUser);

            return new LoginUserResponse()
            {
                Data = mappedUser
            };
        }
    }
}
