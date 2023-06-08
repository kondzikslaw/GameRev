using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ApiControllerBase
    {
        public GamesController(IMediator mediator, ILogger<GamesController> logger) : base(mediator) 
        {
            logger.LogInformation("We are in Games");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGames([FromQuery] GetGamesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("{gameId}")]
        public Task<IActionResult> GetById([FromRoute] int gameId)
        {
            var request = new GetGameByIdRequest()
            {
                GameId = gameId
            };
            return this.HandleRequest<GetGameByIdRequest, GetGameByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddGame([FromBody] AddGamesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        [Route("{gameId}")]
        public async Task<IActionResult> UpdateGame([FromBody] UpdateGameRequest request, [FromRoute] int gameId)
        {
            request.Id = gameId;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        [Route("{gameId}")]
        public async Task<IActionResult> RemoveGame([FromRoute] int gameId)
        {
            var request = new RemoveGameRequest()
            {
                Id = gameId
            };

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
