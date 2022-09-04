using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProductAPI.DTOs;
using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAll(CancellationToken cancellationToken = default);
    
        Task<ProductCategory> GetById(Guid id, CancellationToken cancellationToken = default);
    
        Task Create(ProductCategoryDto productCategoryDto, CancellationToken cancellationToken = default);

        Task Update(Guid id, ProductCategoryDto productCategoryDto, CancellationToken cancellationToken = default);

        Task Delete(Guid id, CancellationToken cancellationToken = default);
    }
}