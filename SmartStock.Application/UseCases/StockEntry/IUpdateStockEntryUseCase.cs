using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases
{
    public interface IUpdateStockEntryUseCase
    {
        Task<Result<bool, Exception>> ExecuteAsync(Guid id, UpdateStockEntryRequest request);
    }
}