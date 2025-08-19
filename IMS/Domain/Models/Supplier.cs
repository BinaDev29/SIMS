using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Common;

namespace Domain.Models
{
    public class Supplier : BaseDomainEntity
    {
        public required string SupplierName { get; set; }
        public required string ContactPerson { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
    }
}