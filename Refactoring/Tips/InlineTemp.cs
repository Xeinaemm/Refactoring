namespace Refactoring.Tips
{
	public class InlineTemp
	{
		public class Inline
		{
			private readonly Order Order = new Order();

			public bool InlineTempAfter => Order.BasePrice > 1000;

			public bool InlineTempBefore()
			{
				var basePrice = Order.BasePrice;
				return basePrice > 1000;
			}
		}

		public class Order
		{
			public int BasePrice => 1000;
		}
	}
}