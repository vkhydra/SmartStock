using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;

namespace SmartStock.Application.UseCases
{
    public class GetStockItemByIdUseCase : IGetStockItemByIdUseCase
    {
        private readonly IStockItemRepository _stockItemRepository;

        public GetStockItemByIdUseCase(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task<GetStockItemResponse> ExecuteAsync(Guid id)
        {
            var stockItem = await _stockItemRepository.GetByIdAsync(id);

            if (stockItem == null)
            {
                throw new Exception($"Stock item with ID {id} not found.");
            }

            return new GetStockItemResponse
            {
                Id = stockItem.Id,
                Name = stockItem.Name,
                Description = stockItem.Description,
                Code = stockItem.Code,
                UnitOfMeasure = stockItem.UnitOfMeasure,
                Attributes = stockItem.Attributes,
                MinimumStockLevel = stockItem.MinimumStockLevel
            };
        }
    }
}