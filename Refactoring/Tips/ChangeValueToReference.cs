using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ChangeValueToReference
	{
		public class CustomerBefore
		{
			public CustomerBefore(string name) => Name = name;
			public string Name { get; }
		}

		public class OrderBefore
		{
			public OrderBefore(string customerName) => Customer = new CustomerBefore(customerName);
			public CustomerBefore Customer { get; }

			public string CustomerName => Customer.Name;
		}

		private class OrderAfter
		{
			public OrderAfter(string customer) => CustomerAfter = CustomerAfter.Create(customer);

			public CustomerAfter CustomerAfter { get; }
		}

		public class CustomerAfter
		{
			private readonly Dictionary<string, CustomerAfter> _instances = new Dictionary<string, CustomerAfter>();
			private CustomerAfter(string name) => Name = name;
			public string Name { get; }

			private static void LoadCustomers()
			{
				new CustomerAfter("Lemon Car Hire").Store();
				new CustomerAfter("Associated Coffee Machines").Store();
				new CustomerAfter("Bilston Gasworks").Store();
			}

			private void Store()
			{
				_instances.Add(Name, this);
			}

			public CustomerAfter Create(string name) => _instances[name];
		}
	}
}