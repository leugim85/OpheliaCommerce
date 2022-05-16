using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpheliaCommerce.Domain.Entities
{
    [Table("ShoppingsDetails")]
    public class ShoppingDetails
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ShoppingId { get; set; }

        [ForeignKey("ShoppingId")]
        public virtual Shopping HeaderShopping { get; set; }
    }
}
