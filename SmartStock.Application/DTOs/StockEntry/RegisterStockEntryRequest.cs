using System.ComponentModel.DataAnnotations;

namespace SmartStock.Application.DTOs
{
    public class RegisterStockEntryRequest
    {
        [Required(ErrorMessage = "Stock Item ID is required.")]
        public Guid StockItemId { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }
    }
}