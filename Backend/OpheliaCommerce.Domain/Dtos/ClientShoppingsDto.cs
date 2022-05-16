namespace OpheliaCommerce.Domain.Dtos
{
    public class ClientShoppingsDto
    {
        public string   Client { get; set; }

        public double TotalAmount { get; set; }

        public DateTime? Date { get; set; }

        public List<ShoppingDetailsDto> ShoppingDetails { get; set; } = new List<ShoppingDetailsDto>();
    }
}
