using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Allergen.Backend.Models.Entities
{
    [Table("ALLERGEN")]
    public class AllergenEfo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("TypeId")]
        public int TypeId { get; set; }
    }
}
