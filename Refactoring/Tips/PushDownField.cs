namespace Refactoring.Tips
{
	public class PushDownField
	{
		public class Before
		{
			public class Employee
			{
				public string Name { get; }
				public string Note { get; }
				public int Grade { get; }
			}

			public class Salesman : Employee
			{
			}

			public class Engineer : Employee
			{
			}
		}

		public class After
		{
			public class Employee
			{
				public string Name { get; }
			}

			public class Salesman : Employee
			{
				public string Note { get; }
			}

			public class Engineer : Employee
			{
				public int Grade { get; }
			}
		}
	}
}