namespace GameRev.DataAccess.Entities
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsBlocked { get; set; }
        public List<GameUser> GameUsers { get; set; }
        public UserRole? UserRole { get; set; }
    }
}
