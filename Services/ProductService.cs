using Microsoft.EntityFrameworkCore;
using zad10.Contexts;
using zad10.Exceptions;
using zad10.Interfaces;
using zad10.Models;
using zad10.RequestModel;
using zad10.ResponseModels;

namespace zad10.Services;

public class ProductService(DatabaseContext context) : IProductService
{
    public async Task<AddProductResponse> AddProductAsync(AddProductModelRequest modelRequest, CancellationToken cancellationToken)
    {
        // Sprawdzenie czy kategorie produktów istnieja
        foreach (var cat in modelRequest.ProductCategories)
        {
            if (!(await context.Categories.AnyAsync(c => c.CategoryId == cat,cancellationToken)))
            {
                throw new NotFoundException(
                    $"Category of id:{cat} could not be found. Aborting adding product operation");
            }
        }

        var prod = new Product
        {
            Name = modelRequest.ProductName,
            Weight = modelRequest.ProductWeight,
            Width = modelRequest.ProductWidth,
            Height = modelRequest.ProductHeight,
            Depth = modelRequest.ProductDepth
        };

         await context.AddAsync(prod,cancellationToken);
         await context.SaveChangesAsync(cancellationToken);

        var prodCat = modelRequest.ProductCategories.Select(c => new ProductCategory
        {
            ProductId = prod.ProductId,
            CategoryId = c
        });

        await context.ProductCategories.AddRangeAsync(prodCat,cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);


        
        
        var prodCatList = new List<AddProductCategoryResponse>();
        foreach (var cat in modelRequest.ProductCategories)
        {
            var prodCatName = await context.Categories.Where(c => c.CategoryId == cat).Select(c => c.Name)
                .FirstOrDefaultAsync(cancellationToken);
            
            prodCatList.Add(new AddProductCategoryResponse()
            {
                CategoryName = prodCatName
            });
        }
        
        return new AddProductResponse()
        {
            ProductName = modelRequest.ProductName,
            ProductWeight = modelRequest.ProductWeight,
            ProductWidth = modelRequest.ProductWidth,
            ProductHeight = modelRequest.ProductHeight,
            ProductDepth = modelRequest.ProductDepth,
            ProductCategories = prodCatList
        };

    }
}