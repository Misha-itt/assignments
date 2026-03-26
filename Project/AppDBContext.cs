using System.Data.Common;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


public class AppDBContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost; database= ormss; user=root; password= Tiger";
        optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<User>Users{get;set;}
    public DbSet<Product>Product{get;set;}
    public DbSet<Orders>Orders{get;set;}
    public DbSet<OrderItem>OrderItem{get;set;}


protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
                    .ToTable("product")
                    .HasData(new Product {Id= 1,Pname="Laptop",Price=50000, Stock=5},
                            new Product {Id = 2 , Pname = "LaptopCharger",Price=1500,Stock=15},
                            new Product{Id  = 3, Pname = "Mobile",Price = 25000,Stock= 10},
                            new Product{Id = 4, Pname="MobileCharger",Price=500,Stock=13}
                    );
    }
}