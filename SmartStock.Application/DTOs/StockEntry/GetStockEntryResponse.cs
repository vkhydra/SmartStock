namespace SmartStock.Application.DTOs
{
    public class GetStockEntryResponse
    {
        public Guid Id { get; set; }
        public Guid StockItemId { get; set; }
        public int Quantity { get; set; }
    }
}