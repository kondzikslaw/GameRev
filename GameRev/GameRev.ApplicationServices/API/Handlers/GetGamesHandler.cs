using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesRequest, GetGamesResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetGamesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;

        }

        public async Task<GetGamesResponse> Handle(GetGamesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGamesQuery();
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
