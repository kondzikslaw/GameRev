namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public interface IGameUsersService
    {
        Task<IEnumerable<GameUser>> GetAll();
        Task<GameUser> GetByGameId(int gameId, int userId);
        Task<GameUser> Create(GameUser gameUser);
    }
}
