using System;
using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ReplaceExceptionWithTest
	{
		private readonly List<int> _values = new List<int>();

		public double GetValueForPeriodBefore(int periodNumber)
		{
			try
			{
				return _values[periodNumber];
			}
			catch (ArgumentOutOfRangeException e)
			{
				return 0;
			}
		}

		public double GetValueForPeriodAfter(int periodNumber) =>
			periodNumber >= _values.Count ? 0 : _values[periodNumber];
	}
}