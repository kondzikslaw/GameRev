using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands.Users
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(GameRevStorageContext context)
        {
            await context.Users.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
