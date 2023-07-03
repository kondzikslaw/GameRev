using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands.GameUsers
{
    public class AddGameUserCommand : CommandBase<GameUser, GameUser>
    {
        public async override Task<GameUser> Execute(GameRevStorageContext context)
        {
            await context.GameUsers.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
