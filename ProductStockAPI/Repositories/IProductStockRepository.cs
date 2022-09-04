using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProductStockAPI.DTOs;
using ProductStockAPI.Models;

namespace ProductStockAPI.Repositories
{
    public interface IProductStockRepository
    {
        Task<List<ProductStock>> GetAll(CancellationToken cancellationToken = default);
    
        Task<ProductStock> GetById(Guid id, CancellationToken cancellationToken = default);
    
        Task Create(ProductStockDto productDto, CancellationToken cancellationToken = default);

        Task AddStock(Guid productId, int newAddedProductCount, CancellationToken cancellationToken = default);

        Task RemoveStock(Guid productId, int newSoldProductCount, CancellationToken cancellationToken = default);
    }
}