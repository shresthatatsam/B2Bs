namespace B2B.DTOs.RequestDTOs.User
{
    public class RegisterRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public Guid Role { get; set; }
        public string Password { get; set; }
    }
}
