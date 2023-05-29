using GameRev.ApplicationServices.API.Domain;
using GameRev.DataAccess;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesRequest, GetGamesResponse>
    {
        private readonly IRepository<Game> _gameRepository;

        public GetGamesHandler(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<GetGamesResponse> Handle(GetGamesRequest request, CancellationToken cancellationToken)
        {
            var games = _gameRepository.GetAll();
            var domainGames = games.Select(x => new Domain.Models.Game()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseDate = x.ReleaseDate
            });

            var response = new GetGamesResponse()
            {
                Data = domainGames.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
