using System;
using System.Threading.Tasks;
using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;

namespace SmartStock.Application.UseCases
{
    public class UpdateStockItemUseCase : IUpdateStockItemUseCase
    {
        private readonly IStockItemRepository _stockItemRepository;

        public UpdateStockItemUseCase(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task<bool> ExecuteAsync(Guid id, UpdateStockItemRequest request)
        {
            var stockItem = await _stockItemRepository.GetByIdAsync(id);

            if (stockItem == null)
            {
                return false;
            }

            stockItem.UpdateDetails(request.Name, request.Description, request.Code, request.UnitOfMeasure, request.Attributes, request.MinimumStockLevel);

            return await _stockItemRepository.UpdateAsync(stockItem);
        }
    }
}