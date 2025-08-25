using System;
using System.Collections.Generic;

namespace Application.DTOs.InwardTransactions
{
    public class CreateInwardTransactionDto
    {
        public required int ItemId { get; set; }
        public required int GodownId { get; set; }
        public required int SupplierId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public required DateTime TransactionDate { get; set; }
        public required string EmployeeId { get; set; }
    }
}