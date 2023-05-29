using GameRev.DataAccess.CQRS.Queries;

namespace GameRev.DataAccess
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
