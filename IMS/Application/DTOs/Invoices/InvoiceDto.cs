using System;
using System.Collections.Generic;

namespace Application.DTOs.Invoices
{
    public class InvoiceDto
    {
        public required int Id { get; set; }
        public required string InvoiceNumber { get; set; }
        public required DateTime InvoiceDate { get; set; }
        public required int CustomerId { get; set; }
        public required decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public ICollection<InvoiceDetailDto> InvoiceDetails { get; set; } = new List<InvoiceDetailDto>();
    }
}