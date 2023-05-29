using System.ComponentModel.DataAnnotations;

namespace GameRev.DataAccess.Entities
{
    [Flags]
    public enum Genre
    {
        Adventure = 1,
        Rpg = 2,
        Arcade = 4,
        Strategy = 8,
        Simulator = 16,
        Puzzle = 32,
        Educational = 64,
        Sports = 128
    }
    public class Game : EntityBase
    {

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<User> Users { get; set; }
        public Genre? Genres { get; set; }
    }
}
