using SmartStock.Application.DTOs;
using SmartStock.Domain.Models;

namespace SmartStock.Application.UseCases
{
    public interface IRegisterStockEntryUseCase
    {
        Task<Result<RegisterStockEntryResponse, Exception>> ExecuteAsync(RegisterStockEntryRequest request);
    }
}