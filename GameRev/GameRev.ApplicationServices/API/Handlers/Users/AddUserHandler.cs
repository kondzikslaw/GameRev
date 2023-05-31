using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Commands.Users;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class AddUserHandler : IRequestHandler<AddUsersRequest, AddUsersResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IMapper _mapper;

        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddUsersResponse> Handle(AddUsersRequest request, CancellationToken cancellationToken)
        {
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
