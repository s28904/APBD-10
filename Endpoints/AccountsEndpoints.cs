using Microsoft.AspNetCore.Http.HttpResults;
using zad10.Interfaces;

namespace zad10.Endpoints;

public static class AccountsEndpoints
{
    public static void RegisterAccountsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("accounts");
        group.MapGet("{accountId:int}", GetAccount);
    }



    private static async Task<IResult> GetAccount(int accountId, IAccountService service, CancellationToken cancellationToken)
    {
        var account = await service.GetAccountByIdAsync(accountId, cancellationToken);
        if (account is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(account);
    }
}