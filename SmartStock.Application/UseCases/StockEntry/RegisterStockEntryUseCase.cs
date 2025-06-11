using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;
using SmartStock.Domain.Models;

namespace SmartStock.Application.UseCases
{
    public class RegisterStockEntryUseCase : IRegisterStockEntryUseCase
    {
        private readonly IStockEntryRepository _stockEntryRepository;
        private readonly IStockItemRepository _stockItemRepository;

        public RegisterStockEntryUseCase(IStockEntryRepository stockEntryRepository, IStockItemRepository stockItemRepository)
        {
            _stockEntryRepository = stockEntryRepository;
            _stockItemRepository = stockItemRepository;
        }

        public async Task<Result<RegisterStockEntryResponse, Exception>> ExecuteAsync(RegisterStockEntryRequest request)
        {
            var newStockEntry = new StockEntry
            (
                request.StockItemId,
                request.Quantity
            );

            if (!await _stockItemRepository.StockItemExistsAsync(request.StockItemId))
            {
                return Result<RegisterStockEntryResponse, Exception>.Failure(new Exception("Stock item does not exist."));
            }

            await _stockEntryRepository.AddAsync(newStockEntry);
            
            var response = new RegisterStockEntryResponse
            {
                Id = newStockEntry.Id,
            };

            return Result<RegisterStockEntryResponse, Exception>.Success(response);
        }
    }
}