using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad10.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Key]
    [ForeignKey("Accounts")]
    [Column("FK_account", Order=0)]
    public int AccountId { get; set; }
    
    public int Amount { get; set; }
    
    
    [Key]
    [ForeignKey("Products")]
    [Column("FK_product", Order=1)]
    public int ProductId { get; set; }
    
    public Product Product { get; set; } = null!;
}