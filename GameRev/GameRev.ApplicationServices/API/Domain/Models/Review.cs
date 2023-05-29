namespace GameRev.ApplicationServices.API.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public double Rate { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }
    }
}
