// Domain/Models/User.cs
using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User : BaseDomainEntity // BaseDomainEntityን እንዲወርስ ተደርጓል
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Role { get; set; }
    }
}