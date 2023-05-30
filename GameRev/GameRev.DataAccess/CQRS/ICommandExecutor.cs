using GameRev.DataAccess.CQRS.Commands;
using Microsoft.AspNetCore.Http;

namespace GameRev.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
