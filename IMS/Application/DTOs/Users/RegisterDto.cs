using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users
{
    public class RegisterDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}