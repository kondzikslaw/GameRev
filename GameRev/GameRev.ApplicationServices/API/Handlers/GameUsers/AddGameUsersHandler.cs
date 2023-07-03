using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.GameUsers;
using GameRev.ApplicationServices.API.Domain.Responses.GameUsers;
using GameRev.DataAccess.CQRS.Commands.GameUsers;
using GameRev.DataAccess.CQRS;
using MediatR;
using GameRev.DataAccess.Entities;

namespace GameRev.ApplicationServices.API.Handlers.GameUsers
{
    public class AddGameUsersHandler : IRequestHandler<AddGameUsersRequest, AddGameUsersResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IMapper _mapper;

        public AddGameUsersHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }
        public async Task<AddGameUsersResponse> Handle(AddGameUsersRequest request, CancellationToken cancellationToken)
        {
            var gameUser = _mapper.Map<GameUser>(request);
            var command = new AddGameUserCommand() { Parameter = gameUser };
            var gameUserFromDb = await _commandExecutor.Execute(command);
            return new AddGameUsersResponse()
            {
                Data = _mapper.Map<Domain.Models.GameUser>(gameUserFromDb)
            };
        }
    }
}
