using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetShop.Models;

namespace SweetShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductRecipe> ProductRecipes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<IngredientPurchase> IngredientPurchases { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        //public DbSet<CartViewModel> CartViewModel { get; set; }
                


       // public DbSet<LoginViewModel> LoginViewModel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensure the base class OnModelCreating is called

            modelBuilder.Entity<IngredientPurchase>()
                .HasKey(ip => ip.PurchaseID);

            modelBuilder.Entity<ProductRecipe>()
                .HasKey(pr => pr.RecipeID);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderID);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.OrderDetailID);

            modelBuilder.Entity<Supplier>()
                .HasKey(s => s.SupplierID);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<CartItem>().HasNoKey();



        }
    }
}
