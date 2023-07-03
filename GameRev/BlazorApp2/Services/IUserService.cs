namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetMe();
    }
}
