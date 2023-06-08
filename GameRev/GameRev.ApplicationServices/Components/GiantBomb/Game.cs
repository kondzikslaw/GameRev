using Newtonsoft.Json;

namespace GameRev.ApplicationServices.Components.GiantBomb
{
    public class Game
    {
        [JsonProperty("results")]
        public ResultsData Results { get; set; }
    }
}
