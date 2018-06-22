namespace Refactoring.Tips
{
	public class RemoveMiddlemanBefore
	{
		private class Person
		{
			public Department Department { get; private set; }

			public Person Manager => Department.Manager;

			public void SetDepartment(Department arg)
			{
				Department = arg;
			}
		}

		private class Department
		{
			public Department(Person manager) => Manager = manager;

			public Person Manager { get; }
		}
	}

	public class RemoveMiddlemanAfter
	{
		private class Person
		{
			public Department Department { get; private set; }

			public void SetDepartment(Department arg)
			{
				Department = arg;
			}
		}

		private class Department
		{
			public Department(Person manager) => Manager = manager;

			public Person Manager { get; }
		}
	}
}