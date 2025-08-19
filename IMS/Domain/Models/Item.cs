using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Models
{
    // Represents a product or item in the inventory.
    public class Item : BaseDomainEntity
    {
        // Item's unique ID is inherited from BaseDomainEntity.

        public required string ItemName { get; set; }
        public required string Description { get; set; }
        public required decimal UnitPrice { get; set; }
        public required int StockQuantity { get; set; }

        // Foreign key to link the item to a specific godown.
        public required int GodownId { get; set; }
        // Navigation property to the Godown model.
        public required Godown Godown { get; set; }
    }
}