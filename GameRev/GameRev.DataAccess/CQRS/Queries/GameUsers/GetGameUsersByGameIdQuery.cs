using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.GameUsers
{
    public class GetGameUsersByGameIdQuery : QueryBase<GameUser>
    {
        public int GameId { get; set; }

        public int UserId { get; set; }

        public override async Task<GameUser> Execute(GameRevStorageContext context)
        {
            //var gameUsers = await context.GameUsers.Where(x => x.Role == GameUserRole.Owner).Select(x => x.GameId == Id).ToListAsync();
            //var result = new GameUser();
            //foreach(var gameUser in gameUsers)
            //{
            //    //result = gameUser;
            //}
            //return result;

            var gameUser = await context.GameUsers.FirstOrDefaultAsync(x => x.GameId == GameId && x.UserId == UserId);
            return gameUser;
        }
    }
}
