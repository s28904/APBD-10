using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; }= null!;
    
    [Column("weight")]
    public double Weight { get; set; }
    
    [Column("width")]
    public double Width { get; set; }
    
    [Column("height")]
    public double Height { get; set; }
    
    [Column("depth")]
    public double Depth { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; } = new List<ProductCategory>();
    public ICollection<ShoppingCart> ShoppingCarts { get; } = new List<ShoppingCart>();
}