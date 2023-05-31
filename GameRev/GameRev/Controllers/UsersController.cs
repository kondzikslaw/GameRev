using GameRev.ApplicationServices.API.Domain.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromBody] AddUsersRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, [FromRoute] int userId)
        {
            request.Id = userId;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> RemoveUser([FromRoute] int userId)
        {
            var request = new RemoveUserRequest()
            {
                Id = userId
            };

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
