using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProductAPI.DTOs;
using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll(CancellationToken cancellationToken = default);
    
        Task<Product> GetById(Guid id, CancellationToken cancellationToken = default);
    
        Task Create(ProductDto productDto, CancellationToken cancellationToken = default);

        Task Update(Guid id, ProductDto productDto, CancellationToken cancellationToken = default);

        Task Delete(Guid id, CancellationToken cancellationToken = default);
    }
}