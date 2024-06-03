using zad10.RequestModel;
using zad10.ResponseModels;

namespace zad10.Interfaces;

public interface IProductService
{
    Task<AddProductResponse> AddProductAsync(AddProductModelRequest modelRequest, CancellationToken cancellationToken);

}