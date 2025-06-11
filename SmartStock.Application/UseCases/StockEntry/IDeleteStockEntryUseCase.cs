using System;

namespace SmartStock.Application.UseCases
{

    public interface IDeleteStockEntryUseCase
    {
        Task<bool> ExecuteAsync(Guid id);
    }
}