using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.ErrorHandling;
using GameRev.DataAccess.CQRS.Queries.Users;
using GameRev.DataAccess.CQRS;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class GetUserMeHandler : IRequestHandler<GetUserMeRequest, GetUserMeResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public GetUserMeHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }

        public async Task<GetUserMeResponse> Handle(GetUserMeRequest request, CancellationToken cancellationToken)
        {
            if (request.Me == "Me" || request.Me == "me")
            {
                var query = new GetUserQuery()
                {
                    Login = request.AuthenticationLogin
                };

                var user = await _queryExecutor.Execute(query);
                if (user == null)
                {
                    return new GetUserMeResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                var mappedUser = _mapper.Map<API.Domain.Models.User>(user);

                return new GetUserMeResponse()
                {
                    Data = mappedUser
                };
            }
            return new GetUserMeResponse()
            {
                Error = new ErrorModel(ErrorType.UnsupportedMethod)
            };
        }
    }
}
