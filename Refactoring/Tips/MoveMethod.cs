namespace Refactoring.Tips
{
	public class MoveMethod
	{
		private class AccountBefore
		{
			private int _daysOverdrawn;

			private AccountType _type;

			private double OverdraftCharge()
			{
				if (_type.IsPremium)
				{
					double result = 10;
					if (_daysOverdrawn > 7) result += (_daysOverdrawn - 7) * 0.85;
					return result;
				}

				return _daysOverdrawn * 1.75;
			}

			private double BankCharge()
			{
				var result = 4.5;
				if (_daysOverdrawn > 0) result += OverdraftCharge();
				return result;
			}
		}

		public class AccountAfter
		{
			private int _daysOverdrawn;
			private AccountType _type;

			private double BankCharge()
			{
				var result = 4.5;
				if (_daysOverdrawn > 0) result += _type.OverdraftCharge(_daysOverdrawn);
				return result;
			}
		}

		private class AccountType
		{
			public bool IsPremium => true;

			public double OverdraftCharge(int daysOverdrawn)
			{
				if (!IsPremium) return daysOverdrawn * 1.75;
				double result = 10;
				if (daysOverdrawn > 7) result += (daysOverdrawn - 7) * 0.85;
				return result;
			}
		}
	}
}