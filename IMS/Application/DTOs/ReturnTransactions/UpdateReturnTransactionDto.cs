using System;
using System.Collections.Generic;

namespace Application.DTOs.ReturnTransactions
{
    public class UpdateReturnTransactionDto
    {
        public required int Id { get; set; }
        public required int ItemId { get; set; }
        public required int GodownId { get; set; }
        public required int CustomerId { get; set; }
        public required int Quantity { get; set; }
        public required string Reason { get; set; }
        public required DateTime TransactionDate { get; set; }
        public required string EmployeeId { get; set; }
    }
}