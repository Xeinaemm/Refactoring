namespace Refactoring.Tips
{
	public class RenameMethod
	{
		private int _officeAreaCode;
		private int _officeNumber;

		public string TelephoneNumberBefore => $"( {_officeAreaCode.ToString()} ) {_officeNumber.ToString()}";

		public string OfficeTelephoneNumberAfter => $"( {_officeAreaCode.ToString()} ) {_officeNumber.ToString()}";
	}
}