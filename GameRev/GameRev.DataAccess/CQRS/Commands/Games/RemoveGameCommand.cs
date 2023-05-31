using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands.Games
{
    public class RemoveGameCommand : CommandBase<Game, bool>
    {
        public override async Task<bool> Execute(GameRevStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Games.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
