using System;
using System.Threading.Tasks;
using SmartStock.Domain.Models;

namespace SmartStock.Application.Interfaces
{
    public interface IStockItemRepository
    {
        Task AddAsync(StockItem stockItem);
        Task<StockItem> GetByIdAsync(Guid id);
        Task<(List<StockItem> Items, int TotalCount)> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> UpdateAsync(StockItem stockItem);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> StockItemExistsAsync(Guid id);
    }
}