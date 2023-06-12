namespace GameRev.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool IsBlocked { get; set; }

        public List<Game> Games { get; set; }
    }
}
