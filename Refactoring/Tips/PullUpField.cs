namespace Refactoring.Tips
{
	public class PullUpField
	{
		public class Before
		{
			public class Employee
			{
			}

			public class Salesman : Employee
			{
				public string Name { get; set; }
			}

			public class Engineer : Employee
			{
				public string Name { get; set; }
			}
		}

		public class After
		{
			public class Employee
			{
				public string Name { get; set; }
			}

			public class Salesman : Employee
			{
			}

			public class Engineer : Employee
			{
			}
		}
	}
}