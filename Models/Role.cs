using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad10.Models;

[Table("Roles")]
public class Role
{
   [Key]
   [Column("PK_role")]
   public int RoleId { get; set; }
   
   [MaxLength(100)]
   [Column("name")]
   public string Name { get; set; }= null!;
   
   
   public ICollection<Account> Accounts { get; } = new List<Account>();
}