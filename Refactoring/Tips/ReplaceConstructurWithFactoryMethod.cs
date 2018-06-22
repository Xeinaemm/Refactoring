namespace Refactoring.Tips
{
	public class ReplaceConstructurWithFactoryMethod
	{
		public class EmployeeBefore
		{
			private int _type;
			private EmployeeBefore(int type) => _type = type;
		}

		public class EmployeeAfter
		{
			private int _type;
			private EmployeeAfter(int type) => _type = type;

			public static EmployeeAfter Create(int type) => new EmployeeAfter(type);
		}
	}
}