using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Users;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Login = request.AuthenticationLogin
            };
            var user = await _queryExecutor.Execute(query);
            var mappedUser = _mapper.Map<Domain.Models.User>(user);
            var response = new GetUserByIdResponse()
            {
                Data = mappedUser
            };
            return response;
        }
    }
}
