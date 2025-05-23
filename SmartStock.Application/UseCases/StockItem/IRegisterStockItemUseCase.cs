using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases
{
    public interface IRegisterStockItemUseCase
    {
        Task<RegisterStockItemResponse> ExecuteAsync(RegisterStockItemRequest request);
    }
}