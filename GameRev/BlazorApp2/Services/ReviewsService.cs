namespace BlazorApp2.Services
{
    using BlazorApp2.Models;
    public class ReviewsService : IReviewsService
    {
        private IHttpService _httpService;

        public ReviewsService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<int> Create(Review review)
        {
            var result = await _httpService.Post<Review>("/reviews", review);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/reviews/{id}");
            return true;
        }

        public Task<IEnumerable<Review>> GetAll()
        {
            return _httpService.Get<IEnumerable<Review>>("/reviews");
        }

        public Task<IEnumerable<Review>> GetByGameId(int gameId)
        {
            return _httpService.Get<IEnumerable<Review>>($"/reviews/gameId/{gameId}");
        }

        public Task<Review> GetById(int id)
        {
            return _httpService.Get<Review>($"/reviews/{id}");
        }

        public async Task<int> Update(Review review)
        {
            var result = await _httpService.Put<Review>($"/reviews/{review.Id}", review);
            return result.Id;
        }
    }
}
