using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Refactoring.Tips
{
	public class ExtractMethodBefore
	{
		private string _name;
		private Order _orders;

		private void PrintOwing()
		{
			// print banner
			Console.WriteLine("**************************");
			Console.WriteLine("***** Customer Owes ******");
			Console.WriteLine("**************************");

			var outstanding = _orders.Elements.Sum(ordersElement => ordersElement.Amount);

			//print details
			Console.WriteLine("name:" + _name);
			Console.WriteLine("amount" + outstanding);
		}
	}

	public class ExtractMethodAfter
	{
		private string _name;
		private Order _orders;

		private void PrintOwing()
		{
			PrintBanner();
			PrintDetails();
		}

		private void PrintDetails()
		{
			Console.WriteLine($"name: {_name}");
			Console.WriteLine($"amount: {GetOutstanding().ToString(CultureInfo.CurrentCulture)}");
		}

		private static void PrintBanner()
		{
			Console.WriteLine("**************************");
			Console.WriteLine("***** Customer Owes ******");
			Console.WriteLine("**************************");
		}

		private double GetOutstanding() =>
			_orders.Elements.Sum(ordersElement => ordersElement.Amount);
	}

	public class Order
	{
		public double Amount => 0.1;

		public IEnumerable<Order> Elements
		{
			get
			{
				yield return new Order();
				yield return new Order();
				yield return new Order();
				yield return new Order();
			}
		}
	}
}