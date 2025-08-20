// Application/DTOs/Invoices/InvoiceDto.cs
using System;
using System.Collections.Generic;

namespace Application.DTOs.Invoices
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public required string InvoiceNumber { get; set; } 
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; } 
        public ICollection<InvoiceDetailDto> InvoiceDetails { get; set; } = new List<InvoiceDetailDto>(); 
    }
}