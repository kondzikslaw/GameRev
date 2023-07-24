namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
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

        public Task<GameUser> GetByGameId(int gameId, int userId)
        {
            return _httpService.Get<GameUser>($"/gameUsers/{gameId}/{userId}");
        }
    }
}
