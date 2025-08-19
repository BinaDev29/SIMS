using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Suppliers
{
    public class UpdateSupplierDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ContactPerson { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
    }
}