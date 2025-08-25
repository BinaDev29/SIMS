namespace Application.DTOs.Reports
{
    public class StockReportDto
    {
        public required int ItemId { get; set; }
        public required string ItemName { get; set; }
        public required int StockQuantity { get; set; }
        public required int GodownId { get; set; }
    }
}