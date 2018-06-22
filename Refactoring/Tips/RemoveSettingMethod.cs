namespace Refactoring.Tips
{
	public class RemoveSettingMethod
	{
		public class AccountBefore
		{
			private string _id;

			private AccountBefore(string id)
			{
				SetId(id);
			}

			private void SetId(string arg)
			{
				_id = arg;
			}
		}

		public class AccountAfter
		{
			private string _id;

			private AccountAfter(string id) => _id = id;
		}
	}
}