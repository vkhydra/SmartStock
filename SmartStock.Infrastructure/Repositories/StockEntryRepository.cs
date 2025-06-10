
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
            throw new NotImplementedException();
        }

        public Task<(List<StockEntry> Entries, int TotalCount)> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<StockEntry> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(StockEntry stockEntry)
        {
            throw new NotImplementedException();
        }
    }
}