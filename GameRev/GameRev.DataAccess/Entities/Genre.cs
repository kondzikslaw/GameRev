using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace GameRev.DataAccess.Entities
{
    //public class Genre : EntityBase
    //{
    //    [Required]
    //    [MaxLength(50)]
    //    public string Name { get; set; }
    //}
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Genre
    {
        Adventure = 1,
        RPG = 2,
        Arcade = 3,
        Strategy = 4,
        Simulator = 5,
        Puzzle = 6,
        Educational = 7,
        Sports = 8
    }
}
