using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return await HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }
        [HttpGet]
        [Route("{me}")]
        public async Task<IActionResult> GetUserMe([FromRoute] string me)
        {
            var request = new GetUserMeRequest()
            {
                Me = me
            };
            return await this.HandleRequest<GetUserMeRequest, GetUserMeResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromBody] AddUsersRequest request)
        {
            return await HandleRequest<AddUsersRequest, AddUsersResponse>(request);
        }
        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, [FromRoute] int userId)
        {
            request.Id = userId;
            return await HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }
        [HttpDelete]
        [Route("{userLogin}")]
        public async Task<IActionResult> RemoveUser([FromRoute] string userLogin)
        {
            var request = new RemoveUserRequest()
            {
                Login = userLogin
            };
            return await HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
        }
    }
}
