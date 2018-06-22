namespace Refactoring.Tips
{
	public class EncapsulateField
	{
		public string NameBefore { get; set; }
		public string NameAfter { get; private set; }

		public void SetName(string name)
		{
			NameAfter = name;
		}
	}
}