using FluentValidation;
using zad10.RequestModel;

namespace zad10.Validators;

public class AddProductModelValidator : AbstractValidator<AddProductModelRequest>
{
    public AddProductModelValidator()
    {
        RuleFor(e => e.ProductName).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(e => e.ProductWeight).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(e => e.ProductWidth).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(e => e.ProductHeight).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(e => e.ProductDepth).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(e => e.ProductCategories).NotNull();
    }
}