using GameRev.DataAccess.CQRS.Commands;

namespace GameRev.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly GameRevStorageContext _context;

        public CommandExecutor(GameRevStorageContext context)
        {

            _context = context;

        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}
