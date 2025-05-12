using System;
using System.Threading.Tasks;
using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases
{
    public interface IUpdateStockItemUseCase
    {
        Task<bool> ExecuteAsync(Guid id, UpdateStockItemRequest request);
    }
}