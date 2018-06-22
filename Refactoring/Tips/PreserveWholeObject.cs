namespace Refactoring.Tips
{
	public class PreserveWholeObjectBefore
	{
		public class Room
		{
			private static TempRange DaysTempRange => new TempRange();

			private bool WithinPlan(HeatingPlan plan)
			{
				var low = DaysTempRange.Low;
				var high = DaysTempRange.High;
				return plan.WithinRange(low, high);
			}
		}

		public class HeatingPlan
		{
			private TempRange _range;
			public bool WithinRange(int low, int high) => low >= _range.Low && high <= _range.High;
		}

		public class TempRange
		{
			public int High => 0;
			public int Low => 0;
		}
	}

	public class PreserveWholeObjectAfter
	{
		public class Room
		{
			public static TempRange DaysTempRange => new TempRange();
			private bool WithinPlan(HeatingPlan plan) => plan.WithinRange(DaysTempRange);
		}

		public class HeatingPlan
		{
			private TempRange _range;

			public bool WithinRange(TempRange roomRange) => _range.Includes(roomRange);
		}

		public class TempRange
		{
			public int High => 0;
			public int Low => 0;

			public bool Includes(TempRange arg) => arg.Low >= Low && arg.High <= High;
		}
	}
}