using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpheliaCommerce.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}