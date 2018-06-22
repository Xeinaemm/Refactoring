namespace Refactoring.Tips
{
	public class ReplaceNestedConditionalWithGuardClausesBefore
	{
		private bool _isDead;
		private bool _isRetired;
		private bool _isSeparated;

		private double NormalPayAmount => 0.0;
		private double SeparatedAmount => 0.0;
		private double DeadAmount => 0.0;

		private double Before()
		{
			double result;
			if (_isDead)
			{
				result = DeadAmount;
			}
			else
			{
				if (_isSeparated)
				{
					result = SeparatedAmount;
				}
				else
				{
					if (_isRetired) result = RetiredAmount();
					else result = NormalPayAmount;
				}
			}

			return result;
		}

		private static double RetiredAmount() => 0.0;

		public double After()
		{
			if (_isDead) return DeadAmount;
			if (_isSeparated) return SeparatedAmount;
			if (_isRetired) return RetiredAmount();
			return NormalPayAmount;
		}
	}
}