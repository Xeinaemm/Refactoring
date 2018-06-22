namespace Refactoring.Tips
{
	public class ConsolidateConditionalExpression
	{
		public class Or
		{
			private bool _isPartTime;
			private int _monthsDisabled;
			private int _seniority;

			public double OrAfter => IsNotEligibleForDisability ? 0 : 1;

			private bool IsNotEligibleForDisability => _seniority < 2 || _monthsDisabled > 12 || _isPartTime;

			public double OrBefore()
			{
				if (_seniority < 2) return 0;
				if (_monthsDisabled > 12) return 0;
				if (_isPartTime) return 0;
				return 1;
			}
		}

		public class And
		{
			private static int LengthOfService => 0;
			private static bool OnVacation => true;
			public double AndAfter => OnVacation && LengthOfService > 10 ? 1 : 0.5;

			public double AndBefore()
			{
				if (OnVacation)
					if (LengthOfService > 10)
						return 1;
				return 0.5;
			}
		}
	}
}