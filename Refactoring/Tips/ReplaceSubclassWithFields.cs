namespace Refactoring.Tips
{
	public class ReplaceSubclassWithFields
	{
		public abstract class PersonBefore
		{
			public abstract bool IsMale { get; }

			public abstract char Code { get; }
		}

		public class Male : PersonBefore
		{
			public override bool IsMale => true;

			public override char Code => 'M';
		}

		public class Female : PersonBefore
		{
			public override bool IsMale => false;

			public override char Code => 'F';
		}

		public class PersonAfter
		{
			public PersonAfter(bool isMale, char code)
			{
				IsMale = isMale;
				Code = code;
			}

			private char Code { get; }

			public bool IsMale { get; }
		}
	}
}