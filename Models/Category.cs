using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad10.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("PK_category")]
    public int CategoryId { get; set; }
    
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; }= null!;
    
    public ICollection<ProductCategory> ProductCategories { get; } = new List<ProductCategory>();
}