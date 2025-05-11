using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;
using SmartStock.Domain.Models;

namespace SmartStock.Application.UseCases
{
    public class RegisterStockItemUseCase : IRegisterStockItemUseCase
    {
        private readonly IStockItemRepository _stockItemRepository;

        public RegisterStockItemUseCase(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task<RegisterStockItemResponse> ExecuteAsync(RegisterStockItemRequest request)
        {
            var newStockItem = new StockItem
            (
                request.Name,
                request.Description,
                request.Code,
                request.UnitOfMeasure
            );

            if(request.Attributes != null)
            {
                foreach (var attribute in request.Attributes)
                {
                    newStockItem.AddAttribute(attribute.Key, attribute.Value);
                }
            }

            newStockItem.SetMinimumStockLevel(request.MinimumStockLevel);

            await _stockItemRepository.AddAsync(newStockItem);

            return new RegisterStockItemResponse {
                Id = newStockItem.Id
            };

        }
    }
}