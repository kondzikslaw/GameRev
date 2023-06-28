using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess.CQRS.Queries.Games
{
    public class GetGamesQuery : QueryBase<List<Game>>
    {
        public string Title { get; set; }

        public double RateMin { get; set; }

        public double RateMax { get; set; }
        public override Task<List<Game>> Execute(GameRevStorageContext context)
        {
            return context.Games
                .Include(x => x.Reviews)
                .Include(x => x.Users)
                .Where(x => (string.IsNullOrEmpty(Title) || x.Title.Contains(Title)) &&
                (RateMin == 0 || x.Reviews.Select(x => x.Rate).Average() >= RateMin) &&
                (RateMax == 0 || x.Reviews.Select(x => x.Rate).Average() <= RateMax))
                .ToListAsync();

        }
    }
}
