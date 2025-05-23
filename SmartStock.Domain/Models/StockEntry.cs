namespace SmartStock.Domain.Models
{
    public class StockLevel
    {
        public Guid Id { get; private set; }
        public Guid StockItemId { get; private set; }
        public int Quantity { get; private set; }

        public StockLevel(Guid stockItemId, int quantity)
        {
            Id = Guid.NewGuid();
            StockItemId = stockItemId;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            Quantity += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            if (Quantity < quantity)
            {
                throw new InvalidOperationException("Cannot remove more quantity than available.");
            }
            Quantity -= quantity;
        }
        
    }
}