using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Games
{
    public class GetGamesRequest : IRequest<GetGamesResponse>
    {
        public string Title { get; set; }
    }
}
