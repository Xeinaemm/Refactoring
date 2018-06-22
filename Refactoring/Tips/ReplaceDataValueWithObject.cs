namespace Refactoring.Tips
{
	public class ReplaceDataValueWithObject
	{
		private class OrderBefore
		{
			public OrderBefore(string customer) => Customer = customer;
			public string Customer { get; }
		}

		private class CustomerAfter
		{
			public CustomerAfter(string name) => Name = name;
			public string Name { get; }
		}

		private class OrderAfter
		{
			private CustomerAfter _customerAfter;

			public OrderAfter(string customerName) => _customerAfter = new CustomerAfter(customerName);

			public string CustomerName => _customerAfter.Name;

			public void SetCustomer(string customerName)
			{
				_customerAfter = new CustomerAfter(customerName);
			}
		}
	}
}