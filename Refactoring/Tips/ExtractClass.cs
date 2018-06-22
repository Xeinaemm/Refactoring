namespace Refactoring.Tips
{
	public class ExtractClass
	{
		private class PersonBefore
		{
			public string Name { get; }
			private string OfficeAreaCode { get; set; }
			private string OfficeNumber { get; set; }
			public string TelephoneNumber => $"( {OfficeAreaCode} ) {OfficeNumber}";

			private void SetOfficeAreaCode(string arg)
			{
				OfficeAreaCode = arg;
			}

			private void SetOfficeNumber(string arg)
			{
				OfficeNumber = arg;
			}
		}

		public class PersonAfter
		{
			private readonly TelephoneNumber _telephoneNumber;

			public PersonAfter(TelephoneNumber telephoneNumber) => _telephoneNumber = telephoneNumber;

			public string Name { get; private set; }
			public string OfficeNumber { get; private set; }
			public string TelephoneNumber => _telephoneNumber.GetTelephoneNumber();
			public string OfficeAreaCode => _telephoneNumber.AreaCode;

			private void SetOfficeNumber(string arg)
			{
				OfficeNumber = arg;
			}
		}

		public class TelephoneNumber
		{
			public string AreaCode { get; private set; }
			public string Number { get; private set; }

			public void SetAreaCode(string arg)
			{
				AreaCode = arg;
			}

			public void SetNumber(string number)
			{
				Number = number;
			}

			public string GetTelephoneNumber() => $"( {AreaCode} ) {Number}";
		}
	}
}