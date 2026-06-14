namespace B2B.DTOs.RequestDTOs.Product
{
    public class ProductRequestDto
    {
        public Guid BusinessId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Guid CategoryId { get; set; }

        public string Status { get; set; }

        public List<IFormFile> Images { get; set; } = new();
    }
}
