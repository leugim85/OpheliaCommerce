using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpheliaCommerce.Domain.Entities
{
    [Table("Clients")]
    public class Client: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        public virtual ICollection<Shopping> ShoppingList { get; set; } = new List<Shopping>();
    }
}
