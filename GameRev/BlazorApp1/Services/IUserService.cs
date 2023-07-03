namespace BlazorApp1.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp1.Models;

    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetMe();
    }
}