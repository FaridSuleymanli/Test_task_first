using System;

namespace ProductStockAPI.Models
{
    public class ProductStock
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}