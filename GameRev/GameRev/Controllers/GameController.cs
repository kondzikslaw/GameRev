using GameRev.DataAccess;
using GameRev.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameRev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IRepository<Game> _gameRepository;
        public GameController(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Game> GetAllGames() => _gameRepository.GetAll();
        [HttpGet]
        [Route("{gameId}")]
        public Game GetGameById(int gameId) => _gameRepository.GetById(gameId);
    }
}
