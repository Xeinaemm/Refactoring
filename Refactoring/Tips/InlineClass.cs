namespace Refactoring.Tips
{
	public class InlineClassBefore
	{
		private class Person
		{
			public string TelephoneNumber => OfficeTelephone.GetTelephoneNumber();

			private TelephoneNumber OfficeTelephone { get; } = new TelephoneNumber();
		}

		private class TelephoneNumber
		{
			public string AreaCode { get; set; }
			public string Number { get; private set; }
			public string GetTelephoneNumber() => $"( {AreaCode} ) {Number}";

			public void SetAreaCode(string arg)
			{
				AreaCode = arg;
			}

			public void SetNumber(string arg)
			{
				Number = arg;
			}
		}
	}

	public class InlineClassAfter
	{
		private class Person
		{
			public string AreaCode { get; private set; }
			public string Number { get; private set; }
			public string GetTelephoneNumber() => $"( {AreaCode} ) {Number}";

			private void SetAreaCode(string arg)
			{
				AreaCode = arg;
			}

			private void SetNumber(string arg)
			{
				Number = arg;
			}
		}
	}
}