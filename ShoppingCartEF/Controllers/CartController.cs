using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartEF.Data;
using ShoppingCartEF.Models;

namespace ShoppingCartEF.Controllers
{
	public class CartController : Controller
	{
		private readonly ShoppingCartContext _context;
		public static string Message;

		public CartController(ShoppingCartContext context)
		{
			_context = context;
		}
		
		public IActionResult Index()
		{
			int totalPrice = 0;
			foreach( Cart c  in LocalData.Cart)
			{
				totalPrice += Int32.Parse(c.Product.Price) * c.Amount;
			}

			ViewBag.TotalPrice = totalPrice;
			ViewBag.Message = Message;

			return View(LocalData.Cart);
		}

		public ActionResult Remove(int id)
		{
			var c = LocalData.Cart.FirstOrDefault(i => i.Product.Id == id);
			if( c == null)
			{
				return RedirectToAction("Index");
			}
			
			if( c.Amount == 1 )
			{
				LocalData.Cart.Remove(c);
			}
			else
			{
				c.Amount -= 1;
			}

			return RedirectToAction("Index");
		}

		public ActionResult CheckOut()
		{
			int totalPrice = 0;
			foreach( Cart c in LocalData.Cart)
			{
				totalPrice += Int32.Parse(c.Product.Price) * c.Amount;
			}

			Order order = new Order();
			order.Paid = false;
			order.Price = totalPrice.ToString();

			_context.Order.Add(order);

			foreach( Cart c in LocalData.Cart)
			{
				OrderDetail orderDetail = new OrderDetail();
				orderDetail.OrderId = order.Id;
				orderDetail.ProductId = c.Product.Id;
				orderDetail.Amount = c.Amount;

				_context.OrderDetails.Add(orderDetail);
			}

			_context.SaveChanges();
			LocalData.Cart.Clear();
			Message = "Your order has been placed. The order ID is: " + order.Id;

			return RedirectToAction("Index");

		}
	}
}