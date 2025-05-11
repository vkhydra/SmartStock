using System;
using System.Threading.Tasks;
using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases
{
    public interface IGetStockItemByIdUseCase
    {
        Task<GetStockItemResponse> ExecuteAsync(Guid id);
    }
}