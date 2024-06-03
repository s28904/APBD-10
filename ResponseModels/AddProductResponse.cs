namespace zad10.ResponseModels;

public class AddProductResponse
{
    public string ProductName { get; set; }
    public double ProductWeight { get; set; }
    public double ProductWidth { get; set; }
    public double ProductHeight { get; set; }
    public double ProductDepth { get; set; }
    public List<AddProductCategoryResponse> ProductCategories { get; set; }
}

public class AddProductCategoryResponse
{
    public string CategoryName { get; set; }
}