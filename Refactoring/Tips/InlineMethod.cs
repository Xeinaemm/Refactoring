namespace Refactoring.Tips
{
	public class InlineMethod
	{
		private int _numberOfLateDeliveries;

		private bool MoreThanFiveLateDeliveriesBefore => _numberOfLateDeliveries > 5;

		private int RatingBefore => MoreThanFiveLateDeliveriesBefore ? 2 : 1;
		private int RatingAfter => _numberOfLateDeliveries > 5 ? 2 : 1;
	}
}