using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Employees
{
    public class UpdateEmployeeDto
    {
        public required int Id { get; set; }
        public required string EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Department { get; set; }
        public required string Role { get; set; }
    }
}