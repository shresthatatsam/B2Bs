namespace B2B.Entities.Product
{
    public class Product
    {
        public Guid Id { get; set; }

        public Guid BusinessId { get; set; }

        public Business Business { get; set; } // Navigation property to the Business entity
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public string Status { get; set; }

        public string ViewCount { get; set; }   

        public DateTime CreatedAt { get; set; }
    }
}
