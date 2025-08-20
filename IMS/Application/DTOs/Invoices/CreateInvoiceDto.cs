using System;
using System.Collections.Generic;

namespace Application.DTOs.Invoices
{
    public class CreateInvoiceDto
    {
        public required DateTime InvoiceDate { get; set; }
        public required int CustomerId { get; set; }
        public string? Status { get; set; }
        public required ICollection<CreateInvoiceDetailDto> InvoiceDetails { get; set; }
    }
}