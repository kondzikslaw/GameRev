using System.ComponentModel.DataAnnotations;

namespace GameRev.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
