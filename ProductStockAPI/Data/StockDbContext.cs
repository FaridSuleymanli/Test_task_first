using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductStockAPI.Models;

namespace ProductStockAPI.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductStock> ProductStocks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}