namespace Refactoring.Tips
{
	public class RemoveAssignmentsToParameters
	{
		private int DiscountBefore(int inputVal, int quantity, int yearToDate)
		{
			if (inputVal > 50) inputVal -= 2;
			if (quantity > 100) inputVal -= 1;
			if (yearToDate > 10000) inputVal -= 4;
			return inputVal;
		}

		private int DiscountAfter(int inputVal, int quantity, int yearToDate)
		{
			var result = inputVal;
			if (inputVal > 50) result -= 2;
			if (quantity > 100) result -= 1;
			if (yearToDate > 10000) result -= 4;
			return result;
		}
	}
}