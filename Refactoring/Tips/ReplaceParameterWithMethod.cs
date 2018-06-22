namespace Refactoring.Tips
{
	public class ReplaceParameterWithMethod
	{
		private int _itemPrice;
		private int _quantity;

		private int BasePrice => _quantity * _itemPrice;

		private int DiscountLevel => _quantity > 100 ? 2 : 1;

		private double PriceAfter
		{
			get
			{
				if (DiscountLevel == 2) return BasePrice * 0.1;
				return BasePrice * 0.05;
			}
		}

		public double GetPriceBefore()
		{
			var basePrice = _quantity * _itemPrice;
			int discountLevel;
			if (_quantity > 100) discountLevel = 2;
			else discountLevel = 1;
			var finalPrice = DiscountedPriceBefore(basePrice, discountLevel);
			return finalPrice;
		}

		private double DiscountedPriceBefore(int basePrice, int discountLevel)
		{
			if (discountLevel == 2) return basePrice * 0.1;
			return basePrice * 0.05;
		}
	}
}