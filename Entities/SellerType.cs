namespace B2B.Entities
{
    public class SellerType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property: One SellerType can belong to many Businesses
        public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();
    }
}
