using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;
using SmartStock.Domain.Models;

namespace SmartStock.Application.UseCases
{
    public class RegisterStockEntryUseCase : IRegisterStockEntryUseCase
    {
        private readonly IStockEntryRepository _stockEntryRepository;

        public RegisterStockEntryUseCase(IStockEntryRepository stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public async Task<RegisterStockEntryResponse> ExecuteAsync(RegisterStockEntryRequest request)
        {
            var newStockEntry = new StockEntry
            (
                request.StockItemId,
                request.Quantity
            );

            await _stockEntryRepository.AddAsync(newStockEntry);

            return new RegisterStockEntryResponse
            {
                Id = newStockEntry.Id,
            };
        }
    }
}