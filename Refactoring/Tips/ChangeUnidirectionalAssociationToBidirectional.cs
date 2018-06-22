using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ChangeUnidirectionalAssociationToBidirectional
	{
		public class OrderBefore
		{
			public CustomerBefore Customer { get; set; }
		}

		public class CustomerBefore
		{
			private HashSet<OrderBefore> FriendOrders { get; } = new HashSet<OrderBefore>();
		}

		public class OrderAfter
		{
			private readonly List<CustomerAfter> _customers = new List<CustomerAfter>();
			public CustomerAfter CustomerAfter { get; private set; }

			public void SetCustomer(CustomerAfter arg)
			{
				CustomerAfter?.FriendOrders.Remove(this);
				CustomerAfter = arg;
				CustomerAfter?.FriendOrders.Add(this);
			}

			public void AddCustomer(CustomerAfter arg)
			{
				arg.FriendOrders.Add(this);
				_customers.Add(arg);
			}

			public void RemoveCustomer(CustomerAfter arg)
			{
				arg.FriendOrders.Remove(this);
				_customers.Remove(arg);
			}
		}

		public class CustomerAfter
		{
			public HashSet<OrderAfter> FriendOrders { get; } = new HashSet<OrderAfter>();

			private void AddOrder(OrderAfter arg)
			{
				arg.SetCustomer(this);
			}

			private void RemoveOrder(OrderAfter arg)
			{
				arg.RemoveCustomer(this);
			}
		}
	}
}