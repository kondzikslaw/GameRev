using GameRev.DataAccess.CQRS.Queries;

namespace GameRev.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly GameRevStorageContext _context;

        public QueryExecutor(GameRevStorageContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}
