using System;
using SmartStock.Application.DTOs;
using SmartStock.Application.Interfaces;

namespace SmartStock.Application.UseCases
{
    public class GetAllStockEntryUseCase : IGetAllStockEntryUseCase
    {
        private readonly IStockEntryRepository _stockEntryRepository;

        public GetAllStockEntryUseCase(IStockEntryRepository stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public async Task<GetAllStockEntryResponse> ExecuteAsync(GetAllStockEntryRequest request)
        {
            var (entries, totalCount) = await _stockEntryRepository.GetAllAsync(request.PageNumber, request.PageSize);

            var entryResponses = entries.Select(entry => new GetStockEntryResponse
            {
                Id = entry.Id,
                StockItemId = entry.StockItemId,
                Quantity = entry.Quantity
            }).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return new GetAllStockEntryResponse
            {
                Items = entryResponses,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages
            };
        }
    }
}


