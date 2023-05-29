namespace GameRev.ApplicationServices.API.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
