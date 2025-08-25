// Application/DTOs/Users/UserDto.cs
namespace Application.DTOs.Users
{
    public class UserDto
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Role { get; set; }
    }
}