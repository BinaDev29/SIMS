using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Common;

namespace Domain.Models
{
    public class OutwardTransaction : BaseDomainEntity
    {
        public required int GodownId { get; set; }
        public required int ItemId { get; set; }
        public required int QuantityDelivered { get; set; }
        public required DateTime OutwardDate { get; set; }
        public required string Destination { get; set; }
        public required string InvoiceNumber { get; set; }
    }
}