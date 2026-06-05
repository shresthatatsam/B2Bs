namespace B2B.DTOs.ResponseDtos.User
{
    public class AuthResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; } // The JWT token for keeping them logged in
        public string Role { get; set; }
    }
}
