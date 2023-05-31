using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands
{
    public class RemoveReviewCommand : CommandBase<Review, bool>
    {
        public override async Task<bool> Execute(GameRevStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Reviews.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
