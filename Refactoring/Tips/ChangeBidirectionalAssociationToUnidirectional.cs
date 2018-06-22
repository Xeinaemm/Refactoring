using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ChangeBidirectionalAssociationToUnidirectional
	{
		public class OrderBefore
		{
			public CustomerBefore Customer { get; private set; }

			public double DiscountedPrice => GrossPrice * (1 - Customer.Discount);

			public double GrossPrice => 0;

			public void SetCustomer(CustomerBefore arg)
			{
				Customer?.FriendOrders.Remove(this);
				Customer = arg;
				Customer?.FriendOrders.Add(this);
			}
		}

		public class CustomerBefore
		{
			public HashSet<OrderBefore> FriendOrders { get; } = new HashSet<OrderBefore>();

			public int Discount => 0;

			private void AddOrder(OrderBefore arg)
			{
				arg.SetCustomer(this);
			}

			private double GetPriceFor(OrderBefore order) => order.DiscountedPrice;
		}

		public class OrderAfter
		{
			public CustomerAfter Customer { get; set; }

			private int GrossPrice => 0;

			public void SetCustomer(CustomerAfter arg)
			{
				Customer?.FriendOrders.Remove(this);
				Customer = arg;
				Customer?.FriendOrders.Add(this);
			}

			public double GetDiscountedPrice(CustomerAfter customerAfter) => customerAfter.Discount;
		}

		public class CustomerAfter
		{
			public HashSet<OrderAfter> FriendOrders { get; } = new HashSet<OrderAfter>();

			public int Discount => 0;

			private void AddOrder(OrderAfter arg)
			{
				arg.SetCustomer(this);
			}

			public double GetPriceFor(OrderAfter order) =>
				FriendOrders.Contains(order) ? order.GetDiscountedPrice(this) : double.NaN;
		}
	}
}