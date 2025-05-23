namespace SmartStock.Application.DTOs
{
    public class GetAllStockItemsRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}