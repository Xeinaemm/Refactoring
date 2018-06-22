using System;

namespace Refactoring.Tips
{
	public class ReplaceErrorCodeWithException
	{
		private int _balance;

		private int WithdrawBefore(int amount)
		{
			if (amount > _balance) return -1;

			_balance -= amount;
			return 0;
		}

		private void WithdrawAfter(int amount)
		{
			if (amount > _balance) throw new BalanceException();
			_balance -= amount;
		}

		private class BalanceException : Exception
		{
		}
	}
}