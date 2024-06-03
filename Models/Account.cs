using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad10.Models;


[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountId { get; set; }
    
    [MaxLength(50)]
    [Column("first_name")]
    public string FirstName { get; set; }= null!;
    
    [MaxLength(50)]
    [Column("last_name")]
    public string LastName { get; set; } = null!;
    
    [MaxLength(80)]
    [Column("email")]
    public string Email { get; set; }= null!;
    
    [MaxLength(9)]
    [Column("phone")]
    public string? PhoneNumber { get; set; }
    
    [Column("FK_role")]
    [ForeignKey("Roles")]
    public int RoleId { get; set; }
    
    
    public Role Role { get; set; } = null!;

    public ICollection<ShoppingCart> ShoppingCarts { get; } = new List<ShoppingCart>();
}