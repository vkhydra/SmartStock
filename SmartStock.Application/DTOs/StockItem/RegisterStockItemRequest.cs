using System.ComponentModel.DataAnnotations;

namespace SmartStock.Application.DTOs
{
    public class RegisterStockItemRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters long.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [MaxLength(20, ErrorMessage = "Code cannot exceed 20 characters.")]
        [RegularExpression(@"^[A-Za-z0-9-]+$", ErrorMessage = "Code can only contain letters, numbers, and hyphens.")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Unit of Measure is required.")]
        [MaxLength(10, ErrorMessage = "Unit of Measure cannot exceed 10 characters.")]
        public string UnitOfMeasure { get; set; } = string.Empty;
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        [Range(0, int.MaxValue, ErrorMessage = "Minimum Stock Level cannot be negative.")]
        public int? MinimumStockLevel { get; set; }
    }
}