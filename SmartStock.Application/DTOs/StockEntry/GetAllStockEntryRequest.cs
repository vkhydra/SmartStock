namespace SmartStock.Application.DTOs
{
    public class GetAllStockEntryRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}