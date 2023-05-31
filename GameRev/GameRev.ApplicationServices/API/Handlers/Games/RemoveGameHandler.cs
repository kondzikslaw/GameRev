using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Commands.Games;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Games;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Games
{
    public class RemoveGameHandler : IRequestHandler<RemoveGameRequest, RemoveGameResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        public RemoveGameHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveGameResponse> Handle(RemoveGameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGameQuery()
            {
                Id = request.Id
            };

            var getGame = await _queryExecutor.Execute(query);

            var mappedGame = _mapper.Map<Game>(getGame);
            var command = new RemoveGameCommand()
            {
                Parameter = mappedGame
            };

            var removedCommand = await _commandExecutor.Execute(command);

            return new RemoveGameResponse()
            {
                Data = removedCommand
            };
        }
    }
}
