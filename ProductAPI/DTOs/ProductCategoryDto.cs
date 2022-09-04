using FluentValidation;

namespace ProductAPI.DTOs
{
    public class ProductCategoryDto
    {
        public string Name { get; set; }
    }
    
    public class ProductCategoryValidator : AbstractValidator<ProductCategoryDto>
    {
        public ProductCategoryValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name field cannot be empty")
                .NotNull().WithMessage("Name field cannot be null")
                .Matches(@"^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$")
                .WithMessage("Characters are not allowed");
        }
    }
}