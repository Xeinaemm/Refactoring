namespace Refactoring.Tips
{
	public class ReplaceTypeCodeWithEnum
	{
		public class PersonBefore
		{
			private readonly int _0 = 0;
			private readonly int _a = 1;
			private readonly int _ab = 3;
			private readonly int _b = 2;
			private readonly int _bloodGroup;

			public PersonBefore(int bloodGroup) => _bloodGroup = bloodGroup;

			public bool CanBeUniversalDonor => _bloodGroup == _0;
		}

		public class PersonAfter
		{
			private readonly int _bloodGroup;

			public PersonAfter(int bloodGroup) => _bloodGroup = bloodGroup;

			public bool CanBeUniversalDonor => _bloodGroup == (int) BloodGroup.O;
		}

		private enum BloodGroup
		{
			O,
			A,
			B,
			AB
		}
	}
}