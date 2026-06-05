namespace B2B.Entities.Users
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; } // Admin, Seller, Buyer

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
