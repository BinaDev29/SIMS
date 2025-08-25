namespace Application.DTOs.Reports
{
    public class GodownReportDto
    {
        public required int Id { get; set; }
        public required string GodownName { get; set; }
        public required int NumberOfItems { get; set; }
    }
}