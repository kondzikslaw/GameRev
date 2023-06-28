using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.Users
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public int Id { get; set; }
        public override Task<List<User>> Execute(GameRevStorageContext context)
        {
            return context.Users
                //.Include(x => x.Games)
                .ToListAsync();
        }
    }
}
