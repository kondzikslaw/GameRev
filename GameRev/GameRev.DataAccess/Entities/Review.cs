using System.ComponentModel.DataAnnotations;

namespace GameRev.DataAccess.Entities
{
    public class Review : EntityBase
    {
        public int? GameId { get; set; }

        public Game? Game { get; set; }

        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [Required]
        [Range(1,10)]
        public double Rate { get; set; }

        [Required]
        [Timestamp]
        public DateTime PublishDate { get; set; }

        [Required]
        [EmailAddress]
        public string AuthorId { get; set; }
    }
}
