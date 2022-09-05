using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProductAPI.Common;
using ProductAPI.Data;
using ProductAPI.DTOs;
using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBaseEfRepository<Product> _repository;

        public ProductRepository(IBaseEfRepository<Product> repository)
        {
            _repository = repository;
        }
        
        public async Task<List<Product>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _repository.GetList(cancellationToken);
        }

        public async Task<Product> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _repository.Get(x => x.Id == id, cancellationToken);

            if (product == null)
                throw new BadHttpRequestException("Product not found");

            return product;
        }

        public async Task Create(ProductDto productDto, CancellationToken cancellationToken = default)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                State = productDto.State,
                ProductCategoryId = productDto.ProductCategoryId
            };

            await _repository.Add(product, cancellationToken);
        }

        public async Task Update(Guid id, ProductDto productDto, CancellationToken cancellationToken = default)
        {
            var productToUpdate = await GetById(id, cancellationToken);

            productToUpdate.Name = productDto.Name;
            productToUpdate.Price = productDto.Price;
            productToUpdate.State = productDto.State;
            productToUpdate.ProductCategoryId = productDto.ProductCategoryId;

            await _repository.Update(productToUpdate, cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var productToDelete = await GetById(id, cancellationToken);
            productToDelete.IsDeleted = true;

            await _repository.Update(productToDelete, cancellationToken);
        }
    }
}