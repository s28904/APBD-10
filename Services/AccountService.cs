using Microsoft.EntityFrameworkCore;
using zad10.Contexts;
using zad10.Exceptions;
using zad10.Interfaces;
using zad10.ResponseModels;

namespace zad10.Services;

public class AccountServic(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountModelResponse?> GetAccountByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await context.Accounts.Where(a => a.AccountId == id)
            .Select(a => new GetAccountModelResponse
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Phone = a.PhoneNumber,
                Role = a.Role.Name,
                Cart = a.ShoppingCarts.Select(cart => new ShoppingCartResponseModel
                {
                    ProductId = cart.ProductId,
                    ProductName = cart.Product.Name,
                    Amount = cart.Amount
                }).ToList()
                
            }).FirstOrDefaultAsync(cancellationToken);

        return result;
    }
}