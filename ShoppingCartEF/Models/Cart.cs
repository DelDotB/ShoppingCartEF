﻿using ShoppingCartEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartEF.Models
{
	public class Cart
	{
		public Product Product { get; set; }
		public int Amount { get; set; }
	}
}
