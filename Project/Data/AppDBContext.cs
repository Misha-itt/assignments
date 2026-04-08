using System.Data.Common;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Project.Models;



    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .ToTable("product")
                .HasData(
                    new Product { Id = 1, Pname = "Laptop", Price = 50000, Stock = 5, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 2, Pname = "Laptop Charger", Price = 1500, Stock = 15, ImageUrl = "https://m.media-amazon.com/images/I/71udkMozQ3L._AC_SL1489_.jpg" },
                    new Product { Id = 3, Pname = "Mobile", Price = 25000, Stock = 10, ImageUrl = "https://th.bing.com/th/id/R.fc73ae7340a79785ed2ac6655051d0d6?rik=SEMYCU828IxtCw" },
                    new Product { Id = 4, Pname = "Mobile Charger", Price = 500, Stock = 13, ImageUrl = "https://th.bing.com/th/id/OIP.L_XVZQ8Vz9zmYHG-27an_QHaGT?w=208&h=180&c=7&r=0&o=7&pid=1.7&rm=3" },
                    new Product { Id = 5, Pname = "Wireless Mouse", Price = 800, Stock = 20, ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60" },
                    new Product { Id = 6, Pname = "Mechanical Keyboard", Price = 3000, Stock = 12, ImageUrl = "https://images.unsplash.com/photo-1593642634367-d91a135587b5?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60" },
                    new Product { Id = 7, Pname = "Gaming Headset", Price = 2500, Stock = 7, ImageUrl = "https://m.media-amazon.com/images/I/81zLDfXdsfL.jpg" },
                    new Product { Id = 8, Pname = "Webcam", Price = 1200, Stock = 8, ImageUrl = "https://images.unsplash.com/photo-1587825140708-dfaf72ae4b04" },
                    new Product { Id = 9, Pname = "USB Hub", Price = 700, Stock = 25, ImageUrl = "https://m.media-amazon.com/images/I/715OTcL3kaL._AC_SL1500_.jpg" },
                    new Product { Id = 10, Pname = "External Hard Drive", Price = 4500, Stock = 10, ImageUrl = "https://m.media-amazon.com/images/I/61wDfddKt5L._AC_.jpg" },
                    new Product { Id = 11, Pname = "SSD 1TB", Price = 8000, Stock = 5, ImageUrl = "https://s13emagst.akamaized.net/products/50830/50829483/images/res_a126340b9468e6ebe28dfaef136309be.jpg" },
                    new Product { Id = 12, Pname = "Router", Price = 3500, Stock = 15, ImageUrl = "https://images.unsplash.com/photo-1581090700223-1a9e1ff1d5a4?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60" },
                    new Product { Id = 13, Pname = "Power Bank", Price = 1200, Stock = 20, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 14, Pname = "Smartwatch", Price = 7000, Stock = 6, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 15, Pname = "Tablet", Price = 15000, Stock = 9, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 16, Pname = "Laptop Stand", Price = 900, Stock = 14, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 17, Pname = "HDMI Cable", Price = 400, Stock = 30, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 18, Pname = "Ethernet Cable", Price = 350, Stock = 40, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 19, Pname = "Bluetooth Speaker", Price = 1800, Stock = 10, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 20, Pname = "Microphone", Price = 2500, Stock = 7, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 21, Pname = "Desk Lamp", Price = 1200, Stock = 12, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 22, Pname = "Office Chair", Price = 5500, Stock = 5, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 23, Pname = "Monitor 24 inch", Price = 12000, Stock = 8, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 24, Pname = "Monitor 27 inch", Price = 18000, Stock = 5, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 25, Pname = "Laptop Sleeve", Price = 700, Stock = 20, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 26, Pname = "USB Flash Drive", Price = 500, Stock = 50, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 27, Pname = "Graphics Card", Price = 40000, Stock = 4, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 28, Pname = "Motherboard", Price = 15000, Stock = 6, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 29, Pname = "Processor", Price = 22000, Stock = 3, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 30, Pname = "RAM 16GB", Price = 7000, Stock = 10, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 31, Pname = "RAM 32GB", Price = 12000, Stock = 5, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 32, Pname = "Cooling Fan", Price = 1500, Stock = 15, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 33, Pname = "CPU Cooler", Price = 3000, Stock = 7, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" },
                    new Product { Id = 34, Pname = "Graphics Card Cooler", Price = 3500, Stock = 6, ImageUrl = "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg" }
                );
        }
    }
