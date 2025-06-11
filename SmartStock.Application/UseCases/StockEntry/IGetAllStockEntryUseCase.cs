using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases
{
    public interface IGetAllStockEntryUseCase
    {
        Task<GetAllStockEntryResponse> ExecuteAsync(GetAllStockEntryRequest request);
    }
}