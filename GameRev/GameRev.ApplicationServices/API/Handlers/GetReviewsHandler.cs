using GameRev.ApplicationServices.API.Domain;
using GameRev.DataAccess;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class GetReviewsHandler : IRequestHandler<GetReviewsRequest, GetReviewsResponse>
    {
        private readonly IRepository<Review> _reviewRepository;

        public GetReviewsHandler(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<GetReviewsResponse> Handle(GetReviewsRequest request, CancellationToken cancellationToken)
        {
            var reviews = _reviewRepository.GetAll();
            var domainReviews = reviews.Select(x => new Domain.Models.Review
            {
                Id = x.Id,
                Content = x.Content,
                Rate = x.Rate,
                PublishDate = x.PublishDate,
                AuthorId = x.AuthorId
            });

            var response = new GetReviewsResponse()
            {
                Data = domainReviews.ToList()
            };

            return Task.FromResult(response);

        }
    }
}
