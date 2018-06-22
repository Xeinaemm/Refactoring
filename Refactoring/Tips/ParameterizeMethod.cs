using System;

namespace Refactoring.Tips
{
	public class ParameterizeMethod
	{
		private int LastUsage => 1;

		protected Dollars BaseChargeBefore()
		{
			var result = Math.Min(LastUsage, 100) * 0.03;
			if (LastUsage > 100) result += (Math.Min(LastUsage, 200) - 100) * 0.05;
			if (LastUsage > 200) result += (LastUsage - 200) * 0.07;
			return new Dollars(result);
		}

		protected Dollars BaseChargeAfter()
		{
			var result = UsageInRange(0, 100) * 0.03;
			result += UsageInRange(100, 200) * 0.05;
			result += UsageInRange(200, int.MaxValue) * 0.07;
			return new Dollars(result);
		}

		private int UsageInRange(int start, int end)
		{
			if (LastUsage > start) return Math.Min(LastUsage, end) - start;
			return 0;
		}

		protected class Dollars
		{
			private double _dollars;

			public Dollars(double dollars) => _dollars = dollars;
		}
	}
}