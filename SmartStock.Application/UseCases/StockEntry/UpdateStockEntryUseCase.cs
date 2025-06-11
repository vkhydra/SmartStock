using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;
using SmartStock.Domain.Models;

namespace SmartStock.Application.UseCases
{
    public class UpdateStockEntryUseCase : IUpdateStockEntryUseCase
    {
        private readonly IStockEntryRepository _stockEntryRepository;
        private readonly IStockItemRepository _stockItemRepository;
        public UpdateStockEntryUseCase(IStockEntryRepository stockEntryRepository, IStockItemRepository stockItemRepository)
        {
            _stockEntryRepository = stockEntryRepository;
            _stockItemRepository = stockItemRepository;
        }

        public async Task<Result<bool, Exception>> ExecuteAsync(Guid id, UpdateStockEntryRequest request)
        {
            var stockEntry = await _stockEntryRepository.GetByIdAsync(id);
            if (stockEntry == null)
            {
                return Result<bool, Exception>.Failure(new Exception("Stock entry not found."));
            }

            if (!await _stockItemRepository.StockItemExistsAsync(request.StockItemId))
            {
                return Result<bool, Exception>.Failure(new Exception("Stock item does not exist."));
            }

            stockEntry.UpdateDetails(request.StockItemId, request.Quantity);

            await _stockEntryRepository.UpdateAsync(stockEntry);

            return Result<bool, Exception>.Success(true);

        }
    }
}