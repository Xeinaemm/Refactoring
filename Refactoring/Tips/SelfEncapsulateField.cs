namespace Refactoring.Tips
{
	public class SelfEncapsulateField
	{
		private class IntRangeBefore
		{
			private readonly int _low;
			private int _high;

			private IntRangeBefore(int low, int high)
			{
				_low = low;
				_high = high;
			}

			private bool Includes(int arg) => arg >= _low && arg <= _high;

			private void Grow(int factor)
			{
				_high = _high * factor;
			}
		}

		private class IntRangeAfter
		{
			public int Low { get; private set; }

			public int High { get; private set; }

			private bool Includes(int arg) => arg >= Low && arg <= High;

			private void Grow(int factor)
			{
				High = High * factor;
			}
		}
	}
}