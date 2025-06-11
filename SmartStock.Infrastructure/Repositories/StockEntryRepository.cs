
using Microsoft.EntityFrameworkCore;
using SmartStock.Application.Interfaces;
using SmartStock.Domain.Models;
using SmartStock.Infrastructure.Data;

namespace SmartStock.Infrastructure.Repositories
{
    public class StockEntryRepository : IStockEntryRepository
    {
        private readonly SmartStockDbContext _dbContext;
        public StockEntryRepository(SmartStockDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(StockEntry stockEntry)
        {
            await _dbContext.StockEntries.AddAsync(stockEntry);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var stockEntry = _dbContext.StockEntries.Find(id);
            if (stockEntry == null)
            {
                return Task.FromResult(false);
            }

            _dbContext.StockEntries.Remove(stockEntry);
            return _dbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public async Task<(List<StockEntry> Entries, int TotalCount)> GetAllAsync(int pageNumber, int pageSize)
        {
            var totalCount = _dbContext.StockEntries.Count();

            var entries = _dbContext.StockEntries
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (entries, totalCount);
        }

        public async Task<StockEntry> GetByIdAsync(Guid id)
        {
            return await _dbContext.StockEntries.FindAsync(id);
        }

        public Task<bool> UpdateAsync(StockEntry stockEntry)
        {
            _dbContext.Entry(stockEntry).State = EntityState.Modified;
            try
            {
                return _dbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Task.FromResult(false);
            }
        }
    }
}