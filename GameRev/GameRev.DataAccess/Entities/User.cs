using System.ComponentModel.DataAnnotations.Schema;

namespace GameRev.DataAccess.Entities
{
    public enum UserRoleEnum
    {
        None,
        User,
        Admin
    }
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsBlocked { get; set; }
        public List<Game>? Games { get; set; }
        public UserRoleEnum? UserRole { get; set; }
    }
}
