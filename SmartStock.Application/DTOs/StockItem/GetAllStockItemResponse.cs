using System.Collections.Generic;

namespace SmartStock.Application.DTOs
{
    public class GetAllStockItemsResponse
    {
        public List<GetStockItemResponse> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}