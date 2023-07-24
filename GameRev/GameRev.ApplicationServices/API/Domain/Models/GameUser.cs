using GameRev.DataAccess.Entities;

namespace GameRev.ApplicationServices.API.Domain.Models
{
    public class GameUser
    {
        public int UserId { get; set; }

        public int GameId { get; set; }

        public GameUserRole Role { get; set; }
    }
}
