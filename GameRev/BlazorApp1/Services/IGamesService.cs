using BlazorApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetAll();
        Task<int> Create(Game game);
        Task<bool> Delete(int id);
        Task<int> Update(Game game);
        Task<Game> GetById(int id);
    }
}
