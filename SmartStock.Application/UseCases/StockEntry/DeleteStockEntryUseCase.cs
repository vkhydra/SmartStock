using System;
using SmartStock.Application.Interfaces;

namespace SmartStock.Application.UseCases;

public class DeleteStockEntryUseCase : IDeleteStockEntryUseCase
{
    private readonly IStockEntryRepository _stockEntryRepository;
    public DeleteStockEntryUseCase(IStockEntryRepository stockEntryRepository)
    {
        _stockEntryRepository = stockEntryRepository;
    }
    public async Task<bool> ExecuteAsync(Guid id)
    {
        var stockEntry = await _stockEntryRepository.GetByIdAsync(id);
        if (stockEntry == null)
        {
            return false;
        }
        await _stockEntryRepository.DeleteAsync(id);
        return true;
    }
}
