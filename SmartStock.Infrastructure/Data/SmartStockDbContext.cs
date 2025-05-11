using Microsoft.EntityFrameworkCore;
using SmartStock.Domain.Models; // Certifique-se de que este namespace está correto

namespace SmartStock.Infrastructure.Data
{
    public class SmartStockDbContext : DbContext
    {
        public SmartStockDbContext(DbContextOptions<SmartStockDbContext> options) : base(options)
        {
        }

        public DbSet<StockItem> StockItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui você pode configurar o mapeamento das entidades para as tabelas
            modelBuilder.Entity<StockItem>().HasKey(si => si.Id);
            // Outras configurações de mapeamento podem vir aqui
        }
    }
}