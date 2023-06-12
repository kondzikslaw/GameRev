using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Games
{
    public class GetGameByIdRequest : RequestBase, IRequest<GetGameByIdResponse>
    {
        public int GameId { get; set; }
    }
}
