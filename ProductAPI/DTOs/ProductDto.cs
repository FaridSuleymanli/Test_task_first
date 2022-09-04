using System;
using FluentValidation;

namespace ProductAPI.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string State { get; set; }

        public Guid ProductCategoryId { get; set; }
    }

    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name field cannot be empty")
                .NotNull().WithMessage("Name field cannot be null")
                .Matches(@"^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$")
                .WithMessage("Characters are not allowed");
        }
    }
}