using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpheliaCommerce.Domain.Entities
{
    [Table("Shoppings")]
    public class Shopping: BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }

        public int? ClientId { get; set; }

        public virtual ICollection<ShoppingDetails> ShoppingDetails { get; set; } = new List<ShoppingDetails>();

        [Required]
        public double TotalPay { get; set; }
    }
}