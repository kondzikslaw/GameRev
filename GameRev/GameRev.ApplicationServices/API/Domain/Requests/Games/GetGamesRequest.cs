using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Games
{
    public class GetGamesRequest : RequestBase, IRequest<GetGamesResponse>
    {
        public string? Title { get; set; }

        public double RateMin { get; set; }

        public double RateMax { get; set; }
    }
}
