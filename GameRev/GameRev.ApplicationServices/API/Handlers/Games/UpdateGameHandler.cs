using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using GameRev.ApplicationServices.API.ErrorHandling;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Commands.Games;
using GameRev.DataAccess.CQRS.Queries.Games;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Games
{
    public class UpdateGameHandler : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        public UpdateGameHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;

        }

        public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGameQuery
            {
                Id = request.Id
            };

            var game = await _queryExecutor.Execute(query);

            if (game is null)
            {
                return new UpdateGameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
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
