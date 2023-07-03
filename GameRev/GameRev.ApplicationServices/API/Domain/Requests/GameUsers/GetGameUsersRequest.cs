using GameRev.ApplicationServices.API.Domain.Responses.GameUsers;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.GameUsers
{
    public class GetGameUsersRequest : RequestBase, IRequest<GetGameUsersResponse>
    {
    }
}
