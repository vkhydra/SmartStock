namespace SmartStock.Domain.Models
{
    public class StockEntry
    {
        public Guid Id { get; private set; }
        public Guid StockItemId { get; private set; }
        public int Quantity { get; private set; }

        public StockEntry(Guid stockItemId, int quantity)
        {
            Id = Guid.NewGuid();
            StockItemId = stockItemId;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            Quantity -= quantity;
        }

        public void UpdateDetails(Guid stockItemId, int quantity)
        {
            if (stockItemId != Guid.Empty)
            {
                StockItemId = stockItemId;
            }
            if (quantity >= 0)
            {
                Quantity = quantity;
            }
        }
        
    }
}