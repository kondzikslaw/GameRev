using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Users;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        public RemoveUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Login = request.Login
            };

            var getUser = await _queryExecutor.Execute(query);

            var mappedUser = _mapper.Map<User>(getUser);
            var command = new RemoveUserCommand()
            {
                Parameter = mappedUser
            };

            var removedCommand = await _commandExecutor.Execute(command);

            return new RemoveUserResponse()
            {
                Data = removedCommand
            };
        }
    }
}
