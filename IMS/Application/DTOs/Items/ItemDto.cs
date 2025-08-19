using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Items
{
    public class ItemDto
    {
        public required int Id { get; set; }
        public required string ItemName { get; set; }
        public required string Description { get; set; }
        public required decimal UnitPrice { get; set; }
        public required int StockQuantity { get; set; }
        public required int GodownId { get; set; }
    }
}