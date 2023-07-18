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

        public async Task<int> Create(User user)
        {
            var result = await _httpService.Post<User>("/users", user);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/users/{id}");
            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _httpService.Get<IEnumerable<User>>("/users");
        }

        public Task<User> GetById(int id)
        {
            return _httpService.Get<User>($"/users/{id}");
        }

        public Task<User> GetByLogin(string login)
        {
            return _httpService.Get<User>($"/users/{login}");
        }

        public async Task<int> Update(User user)
        {
            var result = await _httpService.Put<User>($"/users/{user.Id}", user);
            return result.Id;
        }

        public async Task<User> GetMe()
        {
            return await _httpService.Get<User>("/users/me");
        }
    }
}
