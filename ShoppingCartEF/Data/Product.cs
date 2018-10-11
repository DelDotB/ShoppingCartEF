﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartEF.Data
{
	public class Product
	{
		public Product()
		{
			this.OrderDetails = new HashSet<OrderDetail>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Price { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
