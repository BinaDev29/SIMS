// Application/DTOs/Invoices/InvoiceDetailDto.cs
namespace Application.DTOs.Invoices
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; } // Added this field
    }
}