using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Models
{
    public class ReturnTransaction : BaseDomainEntity
    {
        public required int GodownId { get; set; }
        public required int ItemId { get; set; }
        public required int QuantityReturned { get; set; }
        public required DateTime ReturnDate { get; set; }
        public required string Reason { get; set; }
    }
}