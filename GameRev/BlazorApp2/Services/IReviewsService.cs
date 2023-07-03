namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public interface IReviewsService
    {
        Task<IEnumerable<Review>> GetAll();
        Task<int> Create(Review review);
        Task<bool> Delete(int id);
        Task<int> Update(Review review);
        Task<Review> GetById(int id);
        Task<IEnumerable<Review>> GetByGameId(int gameId);
    }
}
