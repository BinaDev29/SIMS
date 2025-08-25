// Application/DTOs/Users/UserListDto.cs
namespace Application.DTOs.Users
{
    public class UserListDto
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
    }
}