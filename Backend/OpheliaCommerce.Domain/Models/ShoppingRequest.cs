namespace OpheliaCommerce.Domain.Models
{
    public class ShoppingRequest
    {
        public int CLientId { get; set; }

        public DateTime Date { get; set; }

        public List<ProductToShopping> Products { get; set; }
    }
}
