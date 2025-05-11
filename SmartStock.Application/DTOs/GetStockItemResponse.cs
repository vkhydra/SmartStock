namespace SmartStock.Application.DTOs
{
    public class GetStockItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string UnitOfMeasure { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public int? MinimumStockLevel { get; set; }
    }
}