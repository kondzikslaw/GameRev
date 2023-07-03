using BlazorApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public interface IGameUsersService
    {
        Task<IEnumerable<GameUser>> GetAll();
        Task<GameUser> Create(GameUser gameUser);
    }
}
