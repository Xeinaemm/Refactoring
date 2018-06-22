using System;

namespace Refactoring.Tips
{
	public class DecomposeConditional
	{
		private readonly int _quantity = 0;
		private readonly int _summerRate = 0;
		private readonly int _winterRate = 0;
		private readonly int _winterServiceCharge = 0;
		private int _charge;

		public void Before(TimeSpan time)
		{
			if (time > TimeSpan.FromHours(10) || time < TimeSpan.FromHours(20))
				_charge = _quantity * _winterRate + _winterServiceCharge;
			else
				_charge = _quantity * _summerRate;
		}


		public void After(TimeSpan time)
		{
			_charge = IsDay(time) ? DayCharge(_quantity) : NightCharge(_quantity);
		}

		private int NightCharge(int quantity) => quantity * _summerRate;

		private int DayCharge(int quantity) => quantity * _winterRate + _winterServiceCharge;

		private static bool IsDay(TimeSpan time) => time > TimeSpan.FromHours(6) || time < TimeSpan.FromHours(22);
	}
}