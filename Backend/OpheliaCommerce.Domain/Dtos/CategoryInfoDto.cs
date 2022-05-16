namespace OpheliaCommerce.Domain.Dtos
{
    public class CategoryInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public List<ProductByClassDto> Products { get; set; }
    }
}
