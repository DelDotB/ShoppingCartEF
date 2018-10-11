using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartEF.Data
{
	public class ShoppingCartContext : DbContext 
	{
		public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
		{

		}

		public DbSet<Product> Product { get; set; }
		public virtual DbSet<Order> Order { get; set; }

		public virtual DbSet<OrderDetail> OrderDetails { get; set; }
	}


}
