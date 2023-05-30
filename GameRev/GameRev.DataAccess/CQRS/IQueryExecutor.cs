using GameRev.DataAccess.CQRS.Queries;

namespace GameRev.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
