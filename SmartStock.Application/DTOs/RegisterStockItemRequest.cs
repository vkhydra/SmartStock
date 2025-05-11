namespace SmartStock.Application.DTOs
{
    public class RegisterStockItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string UnitOfMeasure { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
        public int? MinimumStockLevel { get; set; }
    }
}