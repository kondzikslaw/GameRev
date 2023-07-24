using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.GameUsers;
using GameRev.ApplicationServices.API.Domain.Responses.GameUsers;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries.GameUsers;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.GameUsers
{
    public class GetGameUsersByGameIdHandler : IRequestHandler<GetGameUsersByGameIdRequest, GetGameUsersByGameIdResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetGameUsersByGameIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetGameUsersByGameIdResponse> Handle(GetGameUsersByGameIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGameUsersByGameIdQuery()
            {
                GameId = request.GameId,
                UserId = request.UserId
            };
            var gameuser = await _queryExecutor.Execute(query);
            var mappedGameUser = _mapper.Map<Domain.Models.GameUser>(gameuser);
            var response = new GetGameUsersByGameIdResponse()
            {
                Data = mappedGameUser
            };
            return response;
        }
    }
}
