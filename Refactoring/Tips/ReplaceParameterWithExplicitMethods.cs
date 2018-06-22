using System;

namespace Refactoring.Tips
{
	public class ReplaceParameterWithExplicitMethods
	{
		public class Before
		{
			private const int ENGINEER = 0;
			private const int SALESMAN = 1;
			private const int MANAGER = 2;

			private static Employee Create(int type)
			{
				switch (type)
				{
					case ENGINEER: return new Engineer();
					case SALESMAN: return new Salesman();
					case MANAGER: return new Manager();
					default: throw new ArgumentException("Incorrect type code value");
				}
			}

			private class Employee
			{
			}

			private class Manager : Employee
			{
			}

			private class Salesman : Employee
			{
			}

			private class Engineer : Employee
			{
			}
		}

		public class After
		{
			private class Engineer : Employee
			{
			}

			private class Manager : Employee
			{
			}

			private class Salesman : Employee
			{
			}

			public class Employee
			{
				public static Employee CreateEngineer => new Engineer();
				public static Employee CreateSalesman => new Salesman();
				public static Employee CreateManager => new Manager();
			}
		}
	}
}