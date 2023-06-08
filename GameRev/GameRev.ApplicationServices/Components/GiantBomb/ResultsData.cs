using Newtonsoft.Json;

namespace GameRev.ApplicationServices.Components.GiantBomb
{
    public class ResultsData
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("expected_release_year")]
        public int ReleaseYear { get; set; }
    }
}
