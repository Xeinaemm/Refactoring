using System;

namespace Refactoring.Tips
{
	public class ReplaceTypeCodeWithSubclasses
	{
		public class EmployeeBefor
		{
			private static int ENGINEER = 0;
			private static int SALESMAN = 1;
			private static int MANAGER = 2;

			private EmployeeBefor(int type) => Type = type;

			public int Type { get; set; }

			private EmployeeBefor Create(int type) => new EmployeeBefor(type);
		}

		public class EmployeeAfter
		{
			protected const int Engineer = 0;
			protected const int Salesman = 1;
			protected const int Manager = 2;

			public virtual int Type { get; }

			public virtual EmployeeAfter Create(int type)
			{
				switch (type)
				{
					case Engineer:
						return new Engineer();
					case Salesman:
						return new Salesman();
					case Manager:
						return new Manager();
					default:
						throw new ArgumentException();
				}
			}
		}

		public class Engineer : EmployeeAfter
		{
			public override int Type => Engineer;

			public override EmployeeAfter Create(int type) =>
				type == Engineer ? new Engineer() : new EmployeeAfter();
		}

		public class Salesman : EmployeeAfter
		{
			public override int Type => Salesman;

			public override EmployeeAfter Create(int type) =>
				type == Engineer ? new Salesman() : new EmployeeAfter();
		}

		public class Manager : EmployeeAfter
		{
			public override int Type => Manager;

			public override EmployeeAfter Create(int type) =>
				type == Engineer ? new Manager() : new EmployeeAfter();
		}
	}
}