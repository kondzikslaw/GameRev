using GameRev.ApplicationServices.API.Domain.Responses.GameUsers;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.GameUsers
{
    public class GetGameUsersByGameIdRequest : RequestBase, IRequest<GetGameUsersByGameIdResponse>
    {
        public int GameId { get; set; }

        public int UserId { get; set; }
    }
}
