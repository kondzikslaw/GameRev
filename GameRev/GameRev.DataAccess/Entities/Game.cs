﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace GameRev.DataAccess.Entities
{
    public class Game : EntityBase
    {

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(4)]
        public int ReleaseYear { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<GameUser> GameUsers { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public List<Genre> Genres { get; set; }
    }
}
