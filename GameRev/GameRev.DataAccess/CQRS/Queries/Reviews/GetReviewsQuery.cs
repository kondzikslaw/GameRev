using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.Reviews
{
    public class GetReviewsQuery : QueryBase<List<Review>>
    {
        public int Id { get; set; }
        public override Task<List<Review>> Execute(GameRevStorageContext context)
        {
            return context.Reviews.ToListAsync();
        }
    }
}
