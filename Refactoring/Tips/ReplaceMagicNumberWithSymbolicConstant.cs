namespace Refactoring.Tips
{
	public class ReplaceMagicNumberWithSymbolicConstant
	{
		private const double GravitationalConstant = 9.81;
		private double PotentialEnergyBefore(double mass, double height) => mass * 9.81 * height;

		private double PotentialEnergyAfter(double mass, double height) => mass * GravitationalConstant * height;
	}
}