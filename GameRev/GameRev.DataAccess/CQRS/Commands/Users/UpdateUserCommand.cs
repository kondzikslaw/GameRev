using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands
{
    public class UpdateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(GameRevStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
