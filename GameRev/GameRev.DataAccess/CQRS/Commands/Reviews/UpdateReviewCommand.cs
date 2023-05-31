using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands
{
    public class UpdateReviewCommand : CommandBase<Review, Review>
    {
        public override async Task<Review> Execute(GameRevStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Reviews.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
