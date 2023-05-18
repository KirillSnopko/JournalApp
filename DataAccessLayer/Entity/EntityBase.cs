
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
