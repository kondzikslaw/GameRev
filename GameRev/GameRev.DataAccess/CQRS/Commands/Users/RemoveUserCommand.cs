using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, bool>
    {
        public override async Task<bool> Execute(GameRevStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
