namespace SmartStock.Application.DTOs
{
    public class GetAllStockEntryResponse
    {
        public List<GetStockEntryResponse> Items { get; set; } = [];
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}