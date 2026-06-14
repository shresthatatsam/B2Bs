namespace B2B.DTOs.ResponseDtos.Product
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }

        public Guid BusinessId { get; set; }

        public string BusinessName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<ProductImageDto> Images { get; set; } = new();
    }
}
