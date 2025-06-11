namespace SmartStock.Application.DTOs
{
    public class GetStockItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string UnitOfMeasure { get; set; } = string.Empty;
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
        public int? MinimumStockLevel { get; set; }
    }
}