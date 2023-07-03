namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public interface IGameUsersService
    {
        Task<IEnumerable<GameUser>> GetAll();
        Task<GameUser> Create(GameUser gameUser);
    }
}
