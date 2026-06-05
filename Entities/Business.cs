namespace B2B.Entities
{
    public class Business
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } // Navigation property to the User entity

        public string BusinessName { get; set; }

        public Guid SellerTypeId { get; set; }

        public SellerType SellerType { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public bool IsApproved { get; set; } 
    }
}
