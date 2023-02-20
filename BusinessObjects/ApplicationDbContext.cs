using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FPTBooks"));
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StoreOwner> StoreOwners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(m => new { m.order_id, m.book_id });
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, cate_name = "Fiction", cate_des = "Related to unrealistic storey" },
                new Category { ID = 2, cate_name = "Finance", cate_des = "Related to financial" });
            modelBuilder.Entity<Book>().HasData(
                new Book { ID = 1, book_name = "The Great Gatsby", book_author = "F. Scott Fitzgerald", book_price = 10.99, quantity = 50, cate_id = 1 }, //owner_id = 1 },
                new Book { ID = 2, book_name = "To Kill a Mockingbird", book_author = "Harper Lee", book_price = 8.99, quantity = 30, cate_id = 1 }, //owner_id = 1 },
                new Book { ID = 3, book_name = "The Alchemist", book_author = "Paulo Coelho", book_price = 12.99, quantity = 20, cate_id = 1 }, //owner_id = 2 },
                new Book { ID = 4, book_name = "Rich Dad Poor Dad", book_author = "Robert Kiyosaki", book_price = 15.99, quantity = 40, cate_id = 2 }, //owner_id = 2 },
                new Book { ID = 5, book_name = "The Intelligent Investor", book_author = "Benjamin Graham", book_price = 20.99, quantity = 10, cate_id = 2 } //owner_id = 3 }
            );

        }

    }
}
