using Microsoft.Extensions.Logging;

namespace GameRev.ApplicationServices.Components.GiantBomb
{
    public interface IGiantBombConnector
    {
        Task<Game> Fetch(string guid);
    }
}
