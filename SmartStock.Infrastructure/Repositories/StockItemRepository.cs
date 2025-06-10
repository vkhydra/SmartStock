
using Microsoft.EntityFrameworkCore;
using SmartStock.Application.Interfaces;
using SmartStock.Domain.Models;
using SmartStock.Infrastructure.Data;

namespace SmartStock.Infrastructure.Repositories
{
    public class StockItemRepository : IStockItemRepository
    {
        private readonly SmartStockDbContext _dbContext;

        public StockItemRepository(SmartStockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(StockItem stockItem)
        {
            await _dbContext.StockItems.AddAsync(stockItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<StockItem> GetByIdAsync(Guid id)
        {
            return await _dbContext.StockItems.FindAsync(id);
        }

        public async Task<(List<StockItem> Items, int TotalCount)> GetAllAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _dbContext.StockItems.CountAsync();

            var items = await _dbContext.StockItems
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        public async Task<bool> UpdateAsync(StockItem item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var stockItem = await _dbContext.StockItems.FindAsync(id);
            if (stockItem == null)
            {
                return false;
            }

            _dbContext.StockItems.Remove(stockItem);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> StockItemExistsAsync(Guid id)
        {
            return await _dbContext.StockItems.AnyAsync(si => si.Id == id);
        }
    }
}