// Application/DTOs/Invoices/CreateInvoiceDetailDto.cs
namespace Application.DTOs.Invoices
{
    public class CreateInvoiceDetailDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}