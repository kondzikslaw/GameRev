using GameRev.DataAccess.Entities;

namespace GameRev.ApplicationServices.API.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }

        public List<string> Genres { get; set; }
        
        public List<string> Reviews { get; set; }

        public double Rate { get; set; }
    }
}
