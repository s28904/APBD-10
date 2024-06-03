using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace zad10.Models;

[Table("Products_Categories")]
public class ProductCategory
{
    
    [Key]
    [ForeignKey("Products")]
    [Column("FK_product", Order = 0)]
    public int ProductId { get; set; }
    
    public Product Product { get; set; } = null!;
    
    [Key]
    [ForeignKey("Categories")]
    [Column("FK_category", Order=1)]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; } = null!;
}