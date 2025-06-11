using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases
{
    public interface IGetStockEntryByIdUseCase
    {
        Task<GetStockEntryResponse> ExecuteAsync(Guid id);
    }
}