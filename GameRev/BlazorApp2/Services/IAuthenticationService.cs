namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}
