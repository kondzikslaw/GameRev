using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.Users
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(GameRevStorageContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            return user;
        }
    }
}
