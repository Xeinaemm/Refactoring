using System;
using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class IntroduceParameterObject
	{
		public class Entry
		{
			private Entry(double value, DateTime chargeDate)
			{
				Value = value;
				ChargeDate = chargeDate;
			}

			public DateTime ChargeDate { get; }

			public double Value { get; }
		}

		public class Account
		{
			private double GetFlowBetweenBefore(DateTime start, DateTime end)
			{
				double result = 0;
				foreach (var i in new List<Entry>())
					if (i.ChargeDate.Equals(start) || i.ChargeDate.Equals(end))
						result += i.Value;
				return result;
			}

			private double GetFlowBetweenAfter(DateRange range)
			{
				double result = 0;
				foreach (var i in new List<Entry>())
					if (range.Includes(i.ChargeDate))
						result += i.Value;
				return result;
			}
		}

		private class DateRange
		{
			private DateRange(DateTime start, DateTime end)
			{
				Start = start;
				End = end;
			}

			public DateTime Start { get; }

			public DateTime End { get; }

			public bool Includes(DateTime arg) => arg.Equals(Start) || arg.Equals(End);
		}
	}
}