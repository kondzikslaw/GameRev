using System.ComponentModel.DataAnnotations;

namespace GameRev.DataAccess.Entities
{
    public class Genre : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
