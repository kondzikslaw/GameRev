using BlazorApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class GameUsersService : IGameUsersService
    {
        private IHttpService _httpService;

        public GameUsersService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<GameUser> Create(GameUser gameUser)
        {
            var result = await _httpService.Post<GameUser>("/gameUsers", gameUser);
            return result;
        }

        public Task<IEnumerable<GameUser>> GetAll()
        {
            return _httpService.Get<IEnumerable<GameUser>>("/gameUsers");
        }
    }
}
