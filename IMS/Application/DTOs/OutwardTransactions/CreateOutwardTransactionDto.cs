using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OutwardTransactions
{
    public class CreateOutwardTransactionDto
    {
        public required int ItemId { get; set; }
        public required int GodownId { get; set; }
        public required int CustomerId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public required DateTime TransactionDate { get; set; }
        public required string EmployeeId { get; set; }
    }
}