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
		
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetailses { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderDetails>().HasKey(m => new { m.order_id, m.book_id });
			modelBuilder.Entity<Category>().HasData(
				new Category { ID = 1, cate_name = "Fiction", accept = true, cate_des = "Related to unrealistic storey" },
				new Category { ID = 2, cate_name = "Finance", accept = false, cate_des = "Related to financial" });
            /*modelBuilder.Entity<Book>().HasData(
				new Book { ID = 1, book_name = "The Great Gatsby", book_author = "F. Scott Fitzgerald", book_price = 10.99, quantity = 50, cate_id = 1, book_img = "png" }, //owner_id = 1 },
				new Book { ID = 2, book_name = "To Kill a Mockingbird", book_author = "Harper Lee", book_price = 8.99, quantity = 30, cate_id = 1, book_img = "png" }, //owner_id = 1 },
				new Book { ID = 3, book_name = "The Alchemist", book_author = "Paulo Coelho", book_price = 12.99, quantity = 20, cate_id = 1, book_img = "png" }, //owner_id = 2 },
				new Book { ID = 4, book_name = "Rich Dad Poor Dad", book_author = "Robert Kiyosaki", book_price = 15.99, quantity = 40, cate_id = 2, book_img = "png" }, //owner_id = 2 },
				new Book { ID = 5, book_name = "The Intelligent Investor", book_author = "Benjamin Graham", book_price = 20.99, quantity = 10, cate_id = 2, book_img = "png" } //owner_id = 3 }
			);*/
            /*modelBuilder.Entity<OrderDetails>().HasData(
				new OrderDetails
				{
					order_id = 1,
					book_id = 1,
					quantity = 2
				},
				new OrderDetails
				{
					order_id = 1,
					book_id = 2,
					quantity = 1
				}
			);	
			modelBuilder.Entity<Order>().HasData(
				new Order
				{
					ID = 1,
					totalPrice = 100.00,
					createdDate = DateTime.Now,
					status = true,
					shippingAddress = "123 Main St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 2,
					totalPrice = 200.00,
					createdDate = DateTime.Now.AddDays(-1),
					status = false,
					shippingAddress = "456 Elm St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 3,
					totalPrice = 50.00,
					createdDate = DateTime.Now.AddDays(-2),
					status = true,
					shippingAddress = "789 Maple St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 4,
					totalPrice = 75.00,
					createdDate = DateTime.Now.AddDays(-3),
					status = false,
					shippingAddress = "101 Oak St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 5,
					totalPrice = 125.00,
					createdDate = DateTime.Now.AddDays(-4),
					status = true,
					shippingAddress = "111 Pine St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 6,
					totalPrice = 150.00,
					createdDate = DateTime.Now.AddDays(-5),
					status = false,
					shippingAddress = "222 Cedar St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 7,
					totalPrice = 200.00,
					createdDate = DateTime.Now.AddDays(-6),
					status = true,
					shippingAddress = "333 Elm St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 8,
					totalPrice = 175.00,
					createdDate = DateTime.Now.AddDays(-7),
					status = false,
					shippingAddress = "444 Birch St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 9,
					totalPrice = 225.00,
					createdDate = DateTime.Now.AddDays(-8),
					status = true,
					shippingAddress = "555 Maple St, Anytown USA",
					cus_id = "ahha"
				},
				new Order
				{
					ID = 10,
					totalPrice = 250.00,
					createdDate = DateTime.Now.AddDays(-9),
					status = false,
					shippingAddress = "666 Oak St, Anytown USA",
					cus_id = "ahha"
				}

);*/

        }

    }
}
