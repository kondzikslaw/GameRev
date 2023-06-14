using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameRev.DataAccess
{
    public class GameRevStorageContextFactory : IDesignTimeDbContextFactory<GameRevStorageContext>
    {
        public GameRevStorageContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<GameRevStorageContext>();
            //optionBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=GameRevStorage;Integrated Security=True;Trust Server Certificate=True");
            optionBuilder.UseSqlServer("Server=tcp:game-rev.database.windows.net,1433;Initial Catalog=GameRevStorage;Persist Security Info=False;User ID=kondzikslaw;Password=kjoptT7y;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new GameRevStorageContext(optionBuilder.Options);
        }
    }
}
