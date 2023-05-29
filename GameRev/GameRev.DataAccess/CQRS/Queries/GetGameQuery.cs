using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries
{
    public class GetGameQuery : QueryBase<Game>
    {
        public int Id { get; set; }
        public override async Task<Game> Execute(GameRevStorageContext context)
        {
            var game = await context.Games.FirstOrDefaultAsync(x => x.Id == Id);
            return game;
        }
    }
}
