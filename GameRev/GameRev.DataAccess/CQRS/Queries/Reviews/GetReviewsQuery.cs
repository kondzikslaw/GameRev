using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.Reviews
{
    public class GetReviewsQuery : QueryBase<List<Review>>
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public override Task<List<Review>> Execute(GameRevStorageContext context)
        {
            return context.Reviews
                .Include(x => x.Game)
                .Where(x => string.IsNullOrEmpty(GameId.ToString()) || x.GameId == GameId)
                .ToListAsync();
        }
    }
}
