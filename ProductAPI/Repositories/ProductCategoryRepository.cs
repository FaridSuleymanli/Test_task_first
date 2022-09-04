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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IBaseEfRepository<ProductCategory> _repository;

        public ProductCategoryRepository(IBaseEfRepository<ProductCategory> repository)
        {
            _repository = repository;
        }
        
        public async Task<List<ProductCategory>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _repository.GetList(cancellationToken);
        }

        public async Task<ProductCategory> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var productCategory = await _repository.Get(x => x.Id == id, cancellationToken);

            if (productCategory == null)
                throw new BadHttpRequestException("");

            return productCategory;
        }

        public async Task Create(ProductCategoryDto productCategoryDto, CancellationToken cancellationToken = default)
        {
            var productCategory = new ProductCategory()
            {
                Name = productCategoryDto.Name
            };

            await _repository.Add(productCategory, cancellationToken);
        }

        public async Task Update(Guid id, ProductCategoryDto productCategoryDto, CancellationToken cancellationToken = default)
        {
            var productCategoryToUpdate = await GetById(id, cancellationToken);

            productCategoryToUpdate.Name = productCategoryDto.Name;

            await _repository.Update(productCategoryToUpdate, cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var productCategoryToDelete = await GetById(id, cancellationToken);

            await _repository.Remove(productCategoryToDelete, cancellationToken);
        }
    }
}