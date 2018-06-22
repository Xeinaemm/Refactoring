namespace Refactoring.Tips
{
	public class ReplaceMethodWithMethodObject
	{
		private class AccountBefore
		{
			private int Delta => 0;

			private int Gamma(int inputVal, int quantity, int yearToDate)
			{
				var importantValue1 = inputVal * quantity + Delta;
				var importantValue2 = inputVal * yearToDate + 100;
				if (yearToDate - importantValue1 > 100) importantValue2 -= 20;
				var importantValue3 =
					importantValue2 * 7;
				return importantValue3 - 2 * importantValue1;
			}
		}

		private class AccountAfter
		{
			private int Gamma(int inputVal, int quantity, int yearToDate) =>
				new Gamma(this, inputVal, quantity, yearToDate).Compute;
		}

		private class Gamma
		{
			private readonly AccountAfter _account;
			private readonly int _inputVal;
			private readonly int _quantity;
			private readonly int _yearToDate;

			public Gamma(AccountAfter account, int inputValArg, int quantityArg, int yearToDateArg)
			{
				_account = account;
				_inputVal = inputValArg;
				_quantity = quantityArg;
				_yearToDate = yearToDateArg;
			}

			public int Compute => ImportantThing(ImportantValue2) * 7 - 2 * ImportantValue1;

			private int ImportantValue2 => _inputVal * _yearToDate + 100;

			private int ImportantValue1 => _inputVal * _quantity + Delta;

			private int Delta => 0;

			private int ImportantThing(int importantValue2)
			{
				if (_yearToDate - ImportantValue1 > 100) importantValue2 -= 20;
				return importantValue2;
			}
		}
	}
}