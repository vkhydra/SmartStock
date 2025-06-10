using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases
{
    public interface IRegisterStockEntryUseCase
    {
        Task<RegisterStockEntryResponse> ExecuteAsync(RegisterStockEntryRequest request);
    }
}