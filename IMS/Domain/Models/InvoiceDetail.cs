// Domain/Models/InvoiceDetail.cs
using Domain.Common;

namespace Domain.Models
{
    public class InvoiceDetail : BaseDomainEntity
    {
        public required int InvoiceId { get; set; }
        public required int ItemId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }

        public Invoice? Invoice { get; set; }
        public Item? Item { get; set; }
    }
}