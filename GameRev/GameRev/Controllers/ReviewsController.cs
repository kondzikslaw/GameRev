using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ApiControllerBase
    {
        public ReviewsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllReviews([FromQuery] GetReviewsRequest request)
        {
            return await HandleRequest<GetReviewsRequest, GetReviewsResponse>(request);
        }
        [HttpGet]
        [Route("{reviewId}")]
        public async Task<IActionResult> GetById([FromRoute] int reviewId)
        {
            var request = new GetReviewByIdRequest()
            {
                ReviewId = reviewId
            };
            return await HandleRequest<GetReviewByIdRequest, GetReviewByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddReview([FromBody] AddReviewsRequest request)
        {
            return this.HandleRequest<AddReviewsRequest, AddReviewsResponse>(request);
        }
        [HttpPut]
        [Route("{reviewId}")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewRequest request, [FromRoute] int reviewId)
        {
            request.Id = reviewId;
            return await HandleRequest<UpdateReviewRequest, UpdateReviewResponse>(request);
        }
        [HttpDelete]
        [Route("{reviewId}")]
        public async Task<IActionResult> RemoveReview([FromRoute] int reviewId)
        {
            var request = new RemoveReviewRequest()
            {
                Id = reviewId
            };

            return await HandleRequest<RemoveReviewRequest, RemoveReviewResponse>(request);
        }
    }
}
