// Domain/Models/Employee.cs
using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee : BaseDomainEntity // BaseDomainEntityን እንዲወርስ ተደርጓል
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
    }
}