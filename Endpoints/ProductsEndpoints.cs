using FluentValidation;
using zad10.Exceptions;
using zad10.Interfaces;
using zad10.Models;
using zad10.RequestModel;
using zad10.ResponseModels;
using zad10.Validators;

namespace zad10.Endpoints;

public static class ProductsEndpoints
{
    public static void RegisterProductsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("products");
        group.MapPost("", AddProduct);
    }

    private static async Task<IResult> AddProduct(AddProductModelRequest request,IValidator<AddProductModelRequest> validator,IProductService service, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request, cancellationToken);


        if (!validate.IsValid)
        {
            return Results.BadRequest(validate.ToDictionary());
        }
        
        try
        {
          var result =  await service.AddProductAsync(request, cancellationToken);
          return Results.Ok(result);
        }
        catch (NotFoundException e)
        {
            return Results.NotFound(e.Message);
        }
    }
}