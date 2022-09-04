using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
using ProductStockAPI.DTOs;
using ProductStockAPI.Models;
using ProductStockAPI.Repositories;

namespace ProductStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly IProductStockRepository _repository;

        public StockController(IProductStockRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<ActionResult<ProductStock>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetAll(cancellationToken));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductStock>> GetById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetById(id, cancellationToken));
        }
        
        [HttpPost]
        public async Task<ActionResult<ProductStock>> Create([FromBody] ProductStockDto productDto, CancellationToken cancellationToken)
        {
            await _repository.Create(productDto, cancellationToken);
            return Ok();
        }
        
        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductStock>> Update(Guid productId, [FromBody] StockCountDto stockDto, CancellationToken cancellationToken)
        {
            await _repository.AddStock(productId, stockDto.ProductCount, cancellationToken);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<ProductStock>> Delete(Guid productId, [FromBody] StockCountDto stockDto, CancellationToken cancellationToken)
        {
            await _repository.RemoveStock(productId, stockDto.ProductCount, cancellationToken);
            return Ok();
        }
    }
}