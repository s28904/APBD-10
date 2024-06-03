namespace zad10.RequestModel;

public class AddProductModelRequest
{
    public string ProductName { get; set; }
    public double ProductWeight { get; set; }
    public double ProductWidth { get; set; }
    public double ProductHeight { get; set; }
    public double ProductDepth { get; set; }
    public List<int> ProductCategories { get; set; }
}