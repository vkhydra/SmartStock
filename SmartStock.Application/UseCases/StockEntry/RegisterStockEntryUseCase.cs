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

        public async Task<RegisterStockEntryResponse> ExecuteAsync(RegisterStockEntryRequest request)
        {
            var newStockEntry = new StockEntry
            (
                request.StockItemId,
                request.Quantity
            );

            var stockItemExists = await _stockItemRepository.StockItemExistsAsync(request.StockItemId);
            if (!stockItemExists)
            {
                throw new ArgumentException("StockItemId não cadastrado.");
            }

            await _stockEntryRepository.AddAsync(newStockEntry);

            return new RegisterStockEntryResponse
            {
                Id = newStockEntry.Id,
            };
        }
    }
}