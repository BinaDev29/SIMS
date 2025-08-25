namespace Application.DTOs.Users
{
    public class UpdateUserDto
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Role { get; set; }
    }
}