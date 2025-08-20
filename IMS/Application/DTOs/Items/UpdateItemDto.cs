// Application/DTOs/Items/UpdateItemDto.cs
using System;

namespace Application.DTOs.Items
{
    public class UpdateItemDto
    {
        public required int Id { get; set; } // Added
        public required string ItemName { get; set; }
        public required int StockQuantity { get; set; }
        public required int GodownId { get; set; }
        public string? Description { get; set; } // Added
        public decimal? UnitPrice { get; set; } // Added
        public string? Type { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}