using System;

namespace Refactoring.Tips
{
	public class ReplaceTypeCodeWithStateOrStrategy
	{
		public class EmployeeBefore
		{
			private const int Engineer = 0;
			private const int Salesman = 1;
			private const int Manager = 2;

			private readonly int _type;
			private int _bonus;
			private int _commission;
			private int _monthlySalary;

			private EmployeeBefore(int type) => _type = type;

			private int PayAmount()
			{
				switch (_type)
				{
					case Engineer: return _monthlySalary;
					case Salesman: return _monthlySalary + _commission;
					case Manager: return _monthlySalary + _bonus;
					default: throw new ArgumentException();
				}
			}
		}

		public class EmployeeAfter
		{
			private int _bonus;
			private int _commission;
			private int _monthlySalary;
			private EmployeeType _type;


			public void SetType(int arg)
			{
				_type = EmployeeType.NewType(arg);
			}

			private int PayAmount()
			{
				switch (_type.TypeCode)
				{
					case EmployeeType.Engineer: return _monthlySalary;
					case EmployeeType.Salesman: return _monthlySalary + _commission;
					case EmployeeType.Manager: return _monthlySalary + _bonus;
					default: throw new ArgumentException();
				}
			}

			public abstract class EmployeeType
			{
				public const int Engineer = 0;
				public const int Salesman = 1;
				public const int Manager = 2;

				public abstract int TypeCode { get; }

				public static EmployeeType NewType(int code)
				{
					switch (code)
					{
						case Engineer:
							return new Engineer();
						case Salesman:
							return new Salesman();
						case Manager:
							return new Manager();
						default: throw new ArgumentException();
					}
				}
			}

			public class Engineer : EmployeeType
			{
				public override int TypeCode => Engineer;
			}

			public class Salesman : EmployeeType
			{
				public override int TypeCode => Salesman;
			}

			public class Manager : EmployeeType
			{
				public override int TypeCode => Manager;
			}
		}
	}
}