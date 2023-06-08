using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ApiControllerBase
    {
        public ReviewsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGames([FromQuery] GetReviewsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("{reviewId}")]
        public async Task<IActionResult> GetById([FromRoute] int reviewId)
        {
            var request = new GetReviewByIdRequest()
            {
                ReviewId = reviewId
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddReview([FromBody] AddReviewsRequest request)
        {
            return this.HandleRequest<AddReviewsRequest, AddReviewsResponse>(request);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("BAD REQUEST");
            //}
            //var response = await _mediator.Send(request);
            //return Ok(response);
        }
        [HttpPatch]
        [Route("{reviewId}")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewRequest request, [FromRoute] int reviewId)
        {
            request.Id = reviewId;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        [Route("{reviewId}")]
        public async Task<IActionResult> RemoveReview([FromRoute] int reviewId)
        {
            var request = new RemoveReviewRequest()
            {
                Id = reviewId
            };

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
