namespace SmartStock.Application.DTOs
{
    public class UpdateStockEntryRequest
    {
        public Guid StockItemId { get; set; }
        public int Quantity { get; set; }
    }
}