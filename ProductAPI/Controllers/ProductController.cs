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
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<ActionResult<Product>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetAll(cancellationToken));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetById(id, cancellationToken));
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] ProductDto productDto, CancellationToken cancellationToken)
        {
            await _repository.Create(productDto, cancellationToken);
            return Ok(productDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(Guid id, [FromBody] ProductDto productDto, CancellationToken cancellationToken)
        {
            await _repository.Update(id, productDto, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}