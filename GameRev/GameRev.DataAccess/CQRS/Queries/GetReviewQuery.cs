using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries
{
    public class GetReviewQuery : QueryBase<Review>
    {
        public int Id { get; set; }
        public override async Task<Review> Execute(GameRevStorageContext context)
        {
            var review = await context.Reviews.FirstOrDefaultAsync(x => x.Id == Id);
            return review;
        }
    }
}
