using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands.Games
{
    public class UpdateGameCommand : CommandBase<Game, Game>
    {
        public override async Task<Game> Execute(GameRevStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Games.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
