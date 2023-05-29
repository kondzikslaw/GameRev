using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries
{
    public class GetGamesQuery : QueryBase<List<Game>>
    {
        public int Id { get; set; }
        public override Task<List<Game>> Execute(GameRevStorageContext context)
        {
            return context.Games.ToListAsync();
        }
    }
}
