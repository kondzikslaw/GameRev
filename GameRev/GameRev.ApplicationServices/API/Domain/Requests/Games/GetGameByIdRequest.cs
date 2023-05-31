using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Games
{
    public class GetGameByIdRequest : IRequest<GetGameByIdResponse>
    {
        public int GameId { get; set; }
    }
}
