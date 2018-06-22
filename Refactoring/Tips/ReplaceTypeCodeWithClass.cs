namespace Refactoring.Tips
{
	public class ReplaceTypeCodeWithClass
	{
		private class PersonBefore
		{
			public static int O = 0;
			public static int A = 1;
			public static int B = 2;
			public static int AB = 3;

			public PersonBefore(int bloodGroup) => BloodGroup = bloodGroup;

			public int BloodGroup { get; private set; }

			public void SetBloodGroup(int arg)
			{
				BloodGroup = arg;
			}
		}

		public class BloodGroup
		{
			public static readonly BloodGroup O = new BloodGroup(0);
			public static readonly BloodGroup A = new BloodGroup(1);
			public static readonly BloodGroup B = new BloodGroup(2);
			public static readonly BloodGroup AB = new BloodGroup(3);
			private static readonly BloodGroup[] Values = {O, A, B, AB};

			private BloodGroup(int code) => Code = code;

			private int Code { get; }

			private static BloodGroup GetBloodGroup(int arg) => Values[arg];
		}

		public class PersonAfter
		{
			public PersonAfter(BloodGroup bloodGroup) => BloodGroup = bloodGroup;

			public BloodGroup BloodGroup { get; private set; }

			public void SetBloodGroup(BloodGroup arg)
			{
				BloodGroup = arg;
			}
		}
	}
}