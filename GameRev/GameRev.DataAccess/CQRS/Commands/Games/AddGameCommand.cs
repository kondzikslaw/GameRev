using GameRev.DataAccess.Entities;

namespace GameRev.DataAccess.CQRS.Commands.Games
{
    public class AddGameCommand : CommandBase<Game, Game>
    {
        public override async Task<Game> Execute(GameRevStorageContext context)
        {
            await context.Games.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
