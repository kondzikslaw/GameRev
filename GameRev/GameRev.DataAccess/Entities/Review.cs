namespace GameRev.DataAccess.Entities
{
    public class Review : EntityBase
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string Content { get; set; }
        public double Rate { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorId { get; set; }
    }
}
