using System;

namespace Refactoring.Tips
{
	public class ConsolidateDuplicateConditionalFragments
	{
		private double _price;
		private double _total;

		private static bool IsSpecialDeal => true;

		public void Before()
		{
			if (IsSpecialDeal)
			{
				_total = _price * 0.95;
				Send();
			}
			else
			{
				_total = _price * 0.98;
				Send();
			}
		}

		private static void Send()
		{
			Console.WriteLine("Hello!");
		}

		public void After()
		{
			if (IsSpecialDeal)
				_total = _price * 0.95;
			else
				_total = _price * 0.98;
			Send();
		}
	}
}