using System;
using FluentValidation;

namespace ProductStockAPI.DTOs
{
    public class ProductStockDto
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}