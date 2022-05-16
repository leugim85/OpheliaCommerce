namespace OpheliaCommerce.Domain.Models
{
    public class ProductToUpdate
    {
        public int Id { get; set; } 

        public int Stock { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
