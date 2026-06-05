using B2B.Enums;

namespace B2B.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public UserRole Role { get; set; } //Enum to define user roles (Admin, Customer, Seller)

        public DateTime CreatedAt { get; set; }
    }
}
