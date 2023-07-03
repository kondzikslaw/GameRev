using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlazorApp2.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public List<Genre> Genres { get; set; }

        public List<string> Reviews { get; set; }

        public List<double> Rates { get; set; }

        public double Rate { get; set; }
    }
}
