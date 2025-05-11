using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;

namespace SmartStock.Application.UseCases
{
    public class GetAllStockItemsUseCase : IGetAllStockItemsUseCase
    {
        private readonly IStockItemRepository _stockItemRepository;

        public GetAllStockItemsUseCase(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task<GetAllStockItemsResponse> ExecuteAsync(GetAllStockItemsRequest request)
        {
            var (items, totalCount) = await _stockItemRepository.GetAllAsync(request.PageNumber, request.PageSize);

            var itemResponses = items.Select(item => new GetStockItemResponse
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Code = item.Code,
                UnitOfMeasure = item.UnitOfMeasure,
                Attributes = item.Attributes,
                MinimumStockLevel = item.MinimumStockLevel
            }).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return new GetAllStockItemsResponse
            {
                Items = itemResponses,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages
            };
        }
    }
}