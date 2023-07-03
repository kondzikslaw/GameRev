namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetAll();
        Task<int> Create(Game game);
        Task<bool> Delete(int id);
        Task<int> Update(Game game);
        Task<Game> GetById(int id);
    }
}
