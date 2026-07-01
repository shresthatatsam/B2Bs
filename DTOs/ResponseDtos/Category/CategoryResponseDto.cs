namespace B2B.DTOs.RequestDTOs.Category
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BusinessId { get; set; }

        public string BusinessName { get; set; } 
    }
}
