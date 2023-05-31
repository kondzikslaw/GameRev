using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Games
{
    public class UpdateGameRequest : IRequest<UpdateGameResponse>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
