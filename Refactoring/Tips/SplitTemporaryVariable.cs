using System;

namespace Refactoring.Tips
{
	public class SplitTemporaryVariable
	{
		private int _delay;
		private double _mass;
		private double _primaryForce;
		private double _secondaryForce;

		private double SecondaryAcc => (_primaryForce + _secondaryForce) / _mass;
		private double PrimaryVel => PrimaryAcc * _delay;
		private double PrimaryAcc => _primaryForce / _mass;

		public double GetDistanceTravelledBefore(int time)
		{
			double result;
			var acc = _primaryForce / _mass;
			var primaryTime = Math.Min(time, _delay);
			result = 0.5 * acc * primaryTime * primaryTime;
			var secondaryTime = time - _delay;

			if (secondaryTime > 0)
			{
				var primaryVel = acc * _delay;
				acc = (_primaryForce + _secondaryForce) / _mass;
				result += primaryVel * secondaryTime + 0.5 * acc * secondaryTime * secondaryTime;
			}

			return result;
		}

		public double GetDistanceTravelledAfter(int time)
		{
			if (GetSecondaryTime(time) <= 0) return 0.5 * PrimaryAcc * GetPowerOfPrimaryTime(time);

			return 0.5 * GetSecondaryTime(time) * (PrimaryAcc * GetPowerOfPrimaryTime(time) + PrimaryVel +
			                                       SecondaryAcc * GetSecondaryTime(time));
		}

		private double GetPowerOfPrimaryTime(int time) => GetPrimaryTime(time) * GetPrimaryTime(time);

		private int GetSecondaryTime(int time) => time - _delay;

		private int GetPrimaryTime(int time) => Math.Min(time, _delay);
	}
}