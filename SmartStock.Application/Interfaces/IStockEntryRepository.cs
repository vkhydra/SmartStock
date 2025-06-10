using SmartStock.Domain.Models;

namespace SmartStock.Application.Interfaces
{
    public interface IStockEntryRepository
    {
        Task AddAsync(StockEntry stockEntry);
        Task<StockEntry> GetByIdAsync(Guid id);
        Task<(List<StockEntry> Entries, int TotalCount)> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> UpdateAsync(StockEntry stockEntry);
        Task<bool> DeleteAsync(Guid id);
    }
}