namespace BlazorApp1.Services
{
    using System.Threading.Tasks;
    using BlazorApp1.Models;

    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}