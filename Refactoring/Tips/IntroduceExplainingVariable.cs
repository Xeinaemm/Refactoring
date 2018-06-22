using System;

namespace Refactoring.Tips
{
	public class IntroduceExplainingVariable
	{
		private int _itemPrice;
		private int _quantity;

		public double PriceAfter => BasePrice - QuantityDiscount + Shipping;

		private double Shipping => Math.Min(BasePrice * 0.1, 100.0);

		private double QuantityDiscount => Math.Max(0, _quantity - 500) * _itemPrice * 0.05;

		private int BasePrice => _quantity * _itemPrice;

		public double PriceBefore => _quantity * _itemPrice - Math.Max(0, _quantity - 500) * _itemPrice * 0.05 +
		                             Math.Min(_quantity * _itemPrice * 0.1, 100.0);
	}
}