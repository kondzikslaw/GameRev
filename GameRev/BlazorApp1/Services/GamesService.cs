using BlazorApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class GamesService : IGamesService
    {
        private IHttpService _httpService;

        public GamesService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<int> Create(Game game)
        {
            var result = await _httpService.Post<Game>("/games", game);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/games/{id}");
            return true;
        }

        public Task<IEnumerable<Game>> GetAll()
        {
            return _httpService.Get<IEnumerable<Game>>("/games");
        }

        public Task<Game> GetById(int id)
        {
            return _httpService.Get<Game>($"/games/{id}");
        }

        public async Task<int> Update(Game game)
        {
            var result = await _httpService.Put<Game>($"/games/{game.Id}", game);
            return result.Id;
        }
    }
}
