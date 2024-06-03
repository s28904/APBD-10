using zad10.Models;

namespace zad10.ResponseModels;

public class GetAccountModelResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Role { get; set; }

    public List<ShoppingCartResponseModel> Cart { get; set; }
}

public class ShoppingCartResponseModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
    
}