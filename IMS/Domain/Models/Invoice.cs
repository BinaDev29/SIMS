// Domain/Models/Invoice.cs
using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Invoice : BaseDomainEntity
    {
        public required string InvoiceNumber { get; set; }
        public required DateTime InvoiceDate { get; set; }
        public required int CustomerId { get; set; }
        public required decimal TotalAmount { get; set; }
        public string? Status { get; set; } // e.g., "Paid", "Pending"

        // Navigation property to the Customer
        public Customer? Customer { get; set; }

        // Navigation property for the items in the invoice
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}