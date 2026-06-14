namespace B2B.DTOs.RequestDTOs.User
{
    public class RegisterRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public Guid RoleId { get; set; }
        public string Password { get; set; }
        public string BusinessName { get; set; }

        public Guid SellerTypeId { get; set; }
    }
}
