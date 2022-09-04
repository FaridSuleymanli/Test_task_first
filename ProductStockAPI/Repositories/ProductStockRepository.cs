using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProductAPI.Common;
using ProductStockAPI.Data;
using ProductStockAPI.DTOs;
using ProductStockAPI.Exceptions;
using ProductStockAPI.Models;

namespace ProductStockAPI.Repositories
{
    public class ProductStockRepository : IProductStockRepository
    {
        private readonly IBaseEfRepository<ProductStock> _repository;

        public ProductStockRepository(IBaseEfRepository<ProductStock> repository)
        {
            _repository = repository;
        }
        
        public async Task<List<ProductStock>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _repository.GetList(cancellationToken);
        }

        public async Task<ProductStock> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var productStock = await _repository.Get(x => x.ProductId == id, cancellationToken);

            if (productStock == null)
                throw new BadHttpRequestException("");

            return productStock;
        }

        public async Task Create(ProductStockDto productDto, CancellationToken cancellationToken = default)
        {
            var productStock = new ProductStock()
            {
                ProductCount = productDto.ProductCount,
                ProductId = productDto.ProductId
            };

            await _repository.Add(productStock, cancellationToken);
        }

        public async Task AddStock(Guid productId, int newAddedProductCount, CancellationToken cancellationToken = default)
        {
            var stockToUpdate = await GetById(productId, cancellationToken);

            stockToUpdate.ProductCount += newAddedProductCount;

            await _repository.Update(stockToUpdate, cancellationToken);
        }

        public async Task RemoveStock(Guid productId, int newSoldProductCount, CancellationToken cancellationToken = default)
        {
            var stockToDelete = await GetById(productId, cancellationToken);

            if (stockToDelete.ProductCount < 1)
            {
                throw new BadRequestException("Out of Stock");
            }

            stockToDelete.ProductCount -= newSoldProductCount;

            await _repository.Update(stockToDelete, cancellationToken);
        }
    }
}