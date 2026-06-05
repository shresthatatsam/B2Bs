using B2B.Enums;

namespace B2B.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }   // FK to Role

        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
