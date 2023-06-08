using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using GameRev.ApplicationServices.Components.GiantBomb;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Games;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GameRev.ApplicationServices.API.Handlers.Games
{
    public class GetGamesHandler : IRequestHandler<GetGamesRequest, GetGamesResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IGiantBombConnector _giantBombConnector;

        public GetGamesHandler(IMapper mapper, IQueryExecutor queryExecutor, IGiantBombConnector giantBombConnector)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _giantBombConnector = giantBombConnector;
        }

        public async Task<GetGamesResponse> Handle(GetGamesRequest request, CancellationToken cancellationToken)
        {
            var game = await _giantBombConnector.Fetch("3030-1");
            var query = new GetGamesQuery();
            //{
            //    Title = request.Title
            //};
            var games = await _queryExecutor.Execute(query);
            var mappedGame = _mapper.Map<List<Domain.Models.Game>>(games);
            var response = new GetGamesResponse()
            {
                Data = mappedGame
            };
            return response;
        }
    }
}
