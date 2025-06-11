using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;

namespace SmartStock.Application.UseCases
{
    public class GetStockEntryByIdUseCase : IGetStockEntryByIdUseCase
    {
        private readonly IStockEntryRepository stockEntryRepository;
        public GetStockEntryByIdUseCase(IStockEntryRepository stockEntryRepository)
        {
            this.stockEntryRepository = stockEntryRepository;
        }

        public async Task<GetStockEntryResponse> ExecuteAsync(Guid id)
        {
            var stockEntry = await stockEntryRepository.GetByIdAsync(id);

            if (stockEntry == null)
            {
                throw new Exception($"Stock entry with ID {id} not found.");
            }

            return new GetStockEntryResponse
            {
                Id = stockEntry.Id,
                StockItemId = stockEntry.StockItemId,
                Quantity = stockEntry.Quantity
            };
        }
    }
}