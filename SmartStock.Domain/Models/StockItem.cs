namespace SmartStock.Domain.Models
{
    public class StockItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }
        public string UnitOfMeasure { get; private set; }
        public Dictionary<string, string> Attributes { get; private set; } = new Dictionary<string, string>();
        public int? MinimumStockLevel { get; private set; }

        // Constructor to create a new StockItem
        public StockItem(string name, string description, string code, string unitOfMeasure)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Code = code;
            UnitOfMeasure = unitOfMeasure;
        }

        // Constructor to reconstruct a StockItem from storage
        public StockItem(Guid id, string name, string description, string code, string unitOfMeasure, Dictionary<string, string> attributes, int? minimumStockLevel)
        {
            Id = id;
            Name = name;
            Description = description;
            Code = code;
            UnitOfMeasure = unitOfMeasure;
            Attributes = attributes;
            MinimumStockLevel = minimumStockLevel;
        }

        // Methods to modify the StockItem (examples)
        public void AddAttribute(string key, string value)
        {
            Attributes[key] = value;
        }

        public void UpdateMinimumStockLevel(int? newLevel)
        {
            MinimumStockLevel = newLevel;
        }

        public void SetMinimumStockLevel(int? minimumStockLevel)
        {
            MinimumStockLevel = minimumStockLevel;
        }

        public void UpdateDetails(string? name, string? description, string? code, string? unitOfMeasure, Dictionary<string, string>? attributes, int? minimumStockLevel)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = name;
            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                Description = description;
            }
            if (!string.IsNullOrWhiteSpace(code))
            {
                Code = code;
            }
            if (!string.IsNullOrWhiteSpace(unitOfMeasure))
            {
                UnitOfMeasure = unitOfMeasure;
            }
            if (attributes != null)
            {
                Attributes = attributes;
            }
            if (minimumStockLevel.HasValue)
            {
                MinimumStockLevel = minimumStockLevel;
            }
        }
    }
}