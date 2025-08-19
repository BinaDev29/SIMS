using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.InwardTransactions
{
    public class CreateInwardTransactionDto
    {
        public int ItemId { get; set; }
        public int GodownId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? EmployeeId { get; set; }
    }
}