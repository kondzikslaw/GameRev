using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int? GameId { get; set; }

        public Game? Game { get; set; }

        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rate { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string AuthorId { get; set; }
    }
}
