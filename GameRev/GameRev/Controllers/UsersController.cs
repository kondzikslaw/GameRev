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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return await HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("{id:int}")]
        public Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var request = new GetUserByIdRequest()
            {
                Id = id
            };
            return HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }
        [HttpGet]
        [Route("{me}")]
        public async Task<IActionResult> GetUserMe([FromRoute] string me)
        {
            var request = new GetUserMeRequest()
            {
                Me = me
            };
            return await HandleRequest<GetUserMeRequest, GetUserMeResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromBody] AddUsersRequest request)
        {
            return await HandleRequest<AddUsersRequest, AddUsersResponse>(request);
        }
        [HttpPut]
        [Route("{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, [FromRoute] int userId)
        {
            request.Id = userId;
            return await HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> RemoveUser([FromRoute] int userId)
        {
            var request = new RemoveUserRequest()
            {
                Id = userId
            };
            return await HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            return await HandleRequest<LoginUserRequest, LoginUserResponse>(request);
        }
    }
}
