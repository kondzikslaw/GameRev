using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.GameUsers
{
    public class GetGameUsersQuery : QueryBase<List<GameUser>>
    {
        public override Task<List<GameUser>> Execute(GameRevStorageContext context)
        {
            return context.GameUsers.ToListAsync();
        }
    }
}
