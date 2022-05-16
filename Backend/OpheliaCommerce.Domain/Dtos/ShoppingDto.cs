namespace OpheliaCommerce.Domain.Dtos
{
    public class ShoppingDto
    {
        public int Id { get; set; }


        public DateTime Date { get; set; }


        public double PayValue { get; set; }


        public List<ProductDto> Products { get; set; }
    }
}
