namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _httpService.Get<IEnumerable<User>>("/users");
        }

        public async Task<User> GetMe()
        {
            return await _httpService.Get<User>("/users/me");
        }
    }
}
