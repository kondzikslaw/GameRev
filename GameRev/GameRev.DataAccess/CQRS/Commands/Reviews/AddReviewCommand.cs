using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands.Reviews
{
    public class AddReviewCommand : CommandBase<Review, Review>
    {
        public override async Task<Review> Execute(GameRevStorageContext context)
        {
            await context.Reviews.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
