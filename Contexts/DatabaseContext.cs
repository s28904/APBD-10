using Microsoft.EntityFrameworkCore;
using zad10.Models;

namespace zad10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductCategory>().HasKey(k => new { k.ProductId, k.CategoryId });

        modelBuilder.Entity<ShoppingCart>().HasKey(k => new { k.AccountId,k.ProductId});
        

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role
            {
                RoleId = 1,
                Name = "User"
            },
            new Role
            {
                RoleId = 2,
                Name = "Admin"
            },
            new Role
            {
                RoleId = 3,
                Name = "Guest"
            }
        });
        
        
        
        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
           new Category
           {
               CategoryId = 1,
               Name = "Kategoria 1"
           },
           new Category
           {
               CategoryId = 2,
               Name = "Kategoria 2"
           },new Category
           {
               CategoryId = 3,
               Name = "Kategoria 3"
           },new Category
           {
               CategoryId = 4,
               Name = "Kategoria 4"
           }
        });
        
        modelBuilder.Entity<Account>().HasData(new List<Account>
        {
           new Account
           {
               AccountId = 1,
               FirstName = "First1",
               LastName = "Last1",
               Email = "Email1",
               PhoneNumber = "123456789",
               RoleId = 1
           },
           new Account
           {
               AccountId = 2,
               FirstName = "First2",
               LastName = "Last2",
               Email = "Email2",
               PhoneNumber = "987654321",
               RoleId = 2
           },new Account
           {
               AccountId = 3,
               FirstName = "First3",
               LastName = "Last3",
               Email = "Email3",
               PhoneNumber = "654321789",
               RoleId = 3
           }
        });
        
        
        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
         new Product
         {
             ProductId = 1,
             Name = "Prod 1",
             Weight = 52.3,
             Width = 10.3,
             Height = 3.10,
             Depth = 5.2,
         },
         new Product
         {
             ProductId = 2,
             Name = "Prod 2",
             Weight = 52.3,
             Width = 10.3,
             Height = 3.10,
             Depth = 5.2,
         },new Product
         {
             ProductId = 3,
             Name = "Prod 3",
             Weight = 52.3,
             Width = 10.3,
             Height = 3.10,
             Depth = 5.2,
         },new Product
         {
             ProductId = 4,
             Name = "Prod 4",
             Weight = 52.3,
             Width = 10.3,
             Height = 3.10,
             Depth = 5.2,
         }
        });
        
        
        
        modelBuilder.Entity<ProductCategory>().HasData(new List<ProductCategory>
        {
            new ProductCategory
            {
                ProductId = 1,
                CategoryId = 1
            },
            new ProductCategory
            {
                ProductId = 2,
                CategoryId = 4
            },
            new ProductCategory
            {
                ProductId = 3,
                CategoryId = 3
            },
            new ProductCategory
            {
                ProductId = 4,
                CategoryId = 1
            }
        });
        
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>
        {
            new ShoppingCart
            {
                AccountId = 1,
                ProductId = 2,
                Amount = 100
            },
            new ShoppingCart
            {
                AccountId = 1,
                ProductId = 4,
                Amount = 25
            },
            new ShoppingCart
            {
                AccountId = 2,
                ProductId = 3,
                Amount = 15
            }
        });
        
    }
}