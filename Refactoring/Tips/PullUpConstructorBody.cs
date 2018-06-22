namespace Refactoring.Tips
{
	public class PullUpConstructorBody
	{
		public class Before
		{
			public class Salesman
			{
				public Salesman(string name, string surname, string note)
				{
					Name = name;
					Surname = surname;
					Note = note;
				}

				public string Name { get; }
				public string Surname { get; }
				public string Note { get; }
			}

			public class Engineer
			{
				public Engineer(string name, string surname, int grade)
				{
					Name = name;
					Surname = surname;
					Grade = grade;
				}

				public string Name { get; }
				public string Surname { get; }
				public int Grade { get; }
			}
		}

		public class After
		{
			public class Employee
			{
				public Employee(string name, string surname)
				{
					Name = name;
					Surname = surname;
				}

				public string Name { get; }
				public string Surname { get; }
			}

			public class Salesman : Employee
			{
				public Salesman(string name, string surname, string note) : base(name, surname) =>
					Note = note;

				public string Note { get; }
			}

			public class Engineer : Employee
			{
				public Engineer(string name, string surname, int grade) : base(name, surname) =>
					Grade = grade;

				public int Grade { get; }
			}
		}
	}
}