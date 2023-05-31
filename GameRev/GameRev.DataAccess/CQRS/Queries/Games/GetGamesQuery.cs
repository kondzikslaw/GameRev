using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.Games
{
    public class GetGamesQuery : QueryBase<List<Game>>
    {
        public string? Title { get; set; }
        public override Task<List<Game>> Execute(GameRevStorageContext context)
        {
            return context.Games.Where(x => x.Title.Contains(Title)).ToListAsync();
        }
    }
}
