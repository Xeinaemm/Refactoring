namespace Refactoring.Tips
{
	public class ExtractSubclassBefore
	{
		public class JobItem
		{
			public JobItem(int unitPrice, int quantity, bool isLabor, Employee employee)
			{
				UnitPrice = unitPrice;
				Quantity = quantity;
				IsLabor = isLabor;
				Employee = employee;
			}

			public int UnitPrice { get; }
			public Employee Employee { get; }
			public bool IsLabor { get; }
			public int Quantity { get; }

			public int TotalPrice => GetUnitPrice() * Quantity;
			public int GetUnitPrice() => IsLabor ? Employee.Rate : UnitPrice;
		}

		public class Employee
		{
			public Employee(int rate) => Rate = rate;
			public int Rate { get; }
		}
	}

	public class ExtractSubclassAfter
	{
		public class JobItem
		{
			protected readonly Employee _employee;

			protected JobItem(int unitPrice, int quantity, Employee employee)
			{
				UnitPrice = unitPrice;
				Quantity = quantity;
				_employee = employee;
			}

			public int Quantity { get; }
			public int UnitPrice { get; }
			protected bool IsLabor => false;

			public int TotalPrice => UnitPrice * Quantity;
		}

		public class LaborItem : JobItem
		{
			public LaborItem(int unitPrice, int quantity, Employee employee) : base(unitPrice, quantity, employee)
			{
			}

			protected new bool IsLabor => true;

			public int GetUnitPrice() => _employee.Rate;
		}

		public class Employee
		{
			public Employee(int rate) => Rate = rate;
			public int Rate { get; }
		}
	}
}