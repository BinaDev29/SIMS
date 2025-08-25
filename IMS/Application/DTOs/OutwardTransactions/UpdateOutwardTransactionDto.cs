using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OutwardTransactions
{
    public class UpdateOutwardTransactionDto
    {
        public required int Id { get; set; }
        public required int ItemId { get; set; }
        public required int GodownId { get; set; }
        public required int CustomerId { get; set; } // Added missing property
        public required int EmployeeId { get; set; } // Added missing property
        public required int QuantityDelivered { get; set; }
        public required int UnitPrice { get; set; } // Added missing property
        public required DateTime OutwardDate { get; set; }
        public required string Destination { get; set; }
        public required string InvoiceNumber { get; set; }
    }
}