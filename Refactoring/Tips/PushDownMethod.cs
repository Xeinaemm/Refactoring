namespace Refactoring.Tips
{
	public class PushDownMethod
	{
		public class Before
		{
			public class Employee
			{
				public string Name { get; private set; }
				public string Note { get; private set; }
				public int Grade { get; private set; }

				public void SetName(string name)
				{
					Name = name;
				}

				public void SetGrade(int grade)
				{
					Grade = grade;
				}

				public void SetNote(string note)
				{
					Note = note;
				}
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
				public string Name { get; private set; }

				public void SetName(string name)
				{
					Name = name;
				}
			}

			public class Salesman : Employee
			{
				public string Note { get; private set; }


				public void SetNote(string note)
				{
					Note = note;
				}
			}

			public class Engineer : Employee
			{
				public int Grade { get; private set; }

				public void SetGrade(int grade)
				{
					Grade = grade;
				}
			}
		}
	}
}