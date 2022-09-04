using FluentValidation;

namespace ProductStockAPI.DTOs
{
    public class StockCountDto
    {
        public int ProductCount { get; set; }
    }
    
    public class StockValidator : AbstractValidator<StockCountDto>
    {
        public StockValidator()
        {
            RuleFor(p => p.ProductCount)
                .GreaterThanOrEqualTo(0).WithMessage("The value cannot be less than 0");
        }
    }
}