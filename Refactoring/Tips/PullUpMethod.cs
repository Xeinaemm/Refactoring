namespace Refactoring.Tips
{
	public class PullUpMethod
	{
		public class Before
		{
			public class Employee
			{
			}

			public class Salesman : Employee
			{
				public string Name { get; private set; }

				public void SetName(string name)
				{
					Name = name;
				}
			}

			public class Engineer : Employee
			{
				public string Name { get; private set; }

				public void SetName(string name)
				{
					Name = name;
				}
			}
		}

		public class After
		{
			public class Employee
			{
				public string Name { get; private set; }

				public void SetName(string name)
				{
					Name = name;
				}
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