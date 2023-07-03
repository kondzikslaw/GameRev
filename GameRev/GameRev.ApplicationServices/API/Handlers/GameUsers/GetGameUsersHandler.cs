using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Responses.GameUsers;
using GameRev.DataAccess.CQRS.Queries.GameUsers;
using GameRev.DataAccess.CQRS;
using MediatR;
using GameRev.ApplicationServices.API.Domain.Requests.GameUsers;

namespace GameRev.ApplicationServices.API.Handlers.GameUsers
{
    public class GetGameUsersHandler : IRequestHandler<GetGameUsersRequest, GetGameUsersResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetGameUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetGameUsersResponse> Handle(GetGameUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGameUsersQuery();
            var gameusers = await _queryExecutor.Execute(query);
            var mappedGameUser = _mapper.Map<List<Domain.Models.GameUser>>(gameusers);
            var response = new GetGameUsersResponse()
            {
                Data = mappedGameUser
            };
            return response;
        }
    }
}
