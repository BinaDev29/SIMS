// Domain/Models/InwardTransaction.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Models
{
    public class InwardTransaction : BaseDomainEntity
    {
        public required int GodownId { get; set; }
        public required int ItemId { get; set; }
        public required int QuantityReceived { get; set; }
        public required DateTime InwardDate { get; set; }
        public required string Source { get; set; }
        public required string InvoiceNumber { get; set; }
    }
}