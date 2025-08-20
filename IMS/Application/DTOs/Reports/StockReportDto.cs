namespace Application.DTOs.Reports
{
    public class StockReportDto // << This must be 'public'
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int StockQuantity { get; set; }
        public int GodownId { get; set; }
    }
}