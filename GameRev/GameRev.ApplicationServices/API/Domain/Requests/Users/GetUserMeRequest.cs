using GameRev.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Users
{
    public class GetUserMeRequest : RequestBase, IRequest<GetUserMeResponse>
    {
        public string Me { get; set; }
    }
}
