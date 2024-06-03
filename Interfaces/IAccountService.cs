using zad10.ResponseModels;

namespace zad10.Interfaces;

public interface IAccountService
{
    Task<GetAccountModelResponse?> GetAccountByIdAsync(int id, CancellationToken cancellationToken);
}