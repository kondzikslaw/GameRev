﻿using GameRev.ApplicationServices.API.Domain.Requests.GameUsers;
using GameRev.ApplicationServices.API.Domain.Responses.GameUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GameUsersController : ApiControllerBase
    {
        public GameUsersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGameUsers([FromQuery] GetGameUsersRequest request)
        {
            return await HandleRequest<GetGameUsersRequest, GetGameUsersResponse>(request);
        }
        [HttpGet]
        [Route("{gameId}/{userId}")]
        public async Task<IActionResult> GetGameUsersByGameId([FromRoute] int gameId, [FromRoute] int userId)
        {
            var request = new GetGameUsersByGameIdRequest()
            {
                GameId = gameId,
                UserId = userId
            };
            return await HandleRequest<GetGameUsersByGameIdRequest, GetGameUsersByGameIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddGameUser([FromBody] AddGameUsersRequest request)
        {
            return await HandleRequest<AddGameUsersRequest, AddGameUsersResponse>(request);
        }
    }
}
