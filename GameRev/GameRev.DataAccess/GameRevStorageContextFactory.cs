using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameRev.DataAccess
{
    public class GameRevStorageContextFactory : IDesignTimeDbContextFactory<GameRevStorageContext>
    {
        public GameRevStorageContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<GameRevStorageContext>();
            optionBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=GameRevStorage;Integrated Security=True;Trust Server Certificate=True");
            return new GameRevStorageContext(optionBuilder.Options);
        }
    }
}
