using GameRev.ApplicationServices.API.Domain.Requests.Games;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> GetById([FromRoute] int gameId)
        {
            var request = new GetGameByIdRequest()
            {
                GameId = gameId
            };
            var response = await _mediator.Send(request);
            return Ok(response);
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
