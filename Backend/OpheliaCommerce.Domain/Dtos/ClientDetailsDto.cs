namespace OpheliaCommerce.Domain.Dtos
{
    public class ClientDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public double TotalSpend { get; set; }


        public string Email { get; set; }

        public List<ShoppingDto> Shoppings { get; set; } = new List<ShoppingDto>();
    }
}
