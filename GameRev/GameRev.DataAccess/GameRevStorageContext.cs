using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess
{
    public class GameRevStorageContext : DbContext
    {
        public GameRevStorageContext(DbContextOptions<GameRevStorageContext> opt) : base(opt)
        {            
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
