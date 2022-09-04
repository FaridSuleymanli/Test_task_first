using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryController(IProductCategoryRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<ActionResult<ProductCategory>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetAll(cancellationToken));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetById(id, cancellationToken));
        }
        
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> Create([FromBody] ProductCategoryDto productCategoryDto, CancellationToken cancellationToken)
        {
            await _repository.Create(productCategoryDto, cancellationToken);
            return Ok(productCategoryDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCategory>> Update(Guid id, [FromBody] ProductCategoryDto productCategoryDto, CancellationToken cancellationToken)
        {
            await _repository.Update(id, productCategoryDto, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategory>> Delete(Guid id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}