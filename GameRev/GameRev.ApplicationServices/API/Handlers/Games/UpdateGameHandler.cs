using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Commands.Games;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Games
{
    public class UpdateGameHandler : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IMapper _mapper;

        public UpdateGameHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;

        }

        public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
        {
            var mappedGame = _mapper.Map<Game>(request);
            var command = new UpdateGameCommand()
            {
                Parameter = mappedGame
            };

            var updatedCommand = await _commandExecutor.Execute(command);

            return new UpdateGameResponse
            {
                Data = _mapper.Map<Domain.Models.Game>(updatedCommand)
            };
        }
    }
}
