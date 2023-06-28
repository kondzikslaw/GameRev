using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ApiControllerBase
    {
        public GamesController(IMediator mediator, ILogger<GamesController> logger) : base(mediator) 
        {
            logger.LogInformation("We are in Games");
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGames([FromQuery] GetGamesRequest request)
        {
            return await HandleRequest<GetGamesRequest, GetGamesResponse>(request);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("{gameId}")]
        public Task<IActionResult> GetById([FromRoute] int gameId)
        {
            var request = new GetGameByIdRequest()
            {
                Id = gameId
            };
            return HandleRequest<GetGameByIdRequest, GetGameByIdResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddGame([FromBody] AddGamesRequest request)
        {
            return await HandleRequest<AddGamesRequest, AddGamesResponse>(request);
        }
        [HttpPut]
        [Route("{gameId}")]
        public async Task<IActionResult> UpdateGame([FromBody] UpdateGameRequest request, [FromRoute] int gameId)
        {
            request.Id = gameId;
            return await HandleRequest<UpdateGameRequest, UpdateGameResponse>(request);
        }
        [HttpDelete]
        [Route("{gameId}")]
        public async Task<IActionResult> RemoveGame([FromRoute] int gameId)
        {
            var request = new RemoveGameRequest()
            {
                Id = gameId
            };

            return await HandleRequest<RemoveGameRequest, RemoveGameResponse>(request);
        }
    }
}
