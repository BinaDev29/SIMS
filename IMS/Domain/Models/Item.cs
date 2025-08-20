// Domain/Models/Item.cs
using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Item : BaseDomainEntity
    {
        public required string ItemName { get; set; }
        public required int StockQuantity { get; set; }
        public required int GodownId { get; set; }

        public string? Description { get; set; } // Added
        public decimal? UnitPrice { get; set; } // Added
        public string? Type { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public required Godown Godown { get; set; }
    }
}