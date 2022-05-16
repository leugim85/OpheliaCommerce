using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpheliaCommerce.Domain.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

         public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
