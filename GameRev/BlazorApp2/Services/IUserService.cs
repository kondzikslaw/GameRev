namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetMe();
        Task<int> Create(User user);
        Task<bool> Delete(int id);
        Task<int> Update(User user);
        Task<User> GetByLogin(string login);
        Task<User> GetById(int id);
    }
}
