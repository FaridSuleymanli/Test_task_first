using System;
using ProductAPI.Common;

namespace ProductAPI.Models
{
    public class Product : BaseModel<Guid>
    {
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string State { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ProductCategoryId { get; set; }
    }
}