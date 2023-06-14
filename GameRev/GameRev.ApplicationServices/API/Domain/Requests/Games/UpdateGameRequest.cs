using GameRev.ApplicationServices.API.Domain.Responses.Games;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Games
{
    public class UpdateGameRequest : RequestBase, IRequest<UpdateGameResponse>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
