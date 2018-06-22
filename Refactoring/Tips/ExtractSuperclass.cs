using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ExtractSuperclassBefore
	{
		public class Employee
		{
			public Employee(string name, string id, int annualCost)
			{
				Name = name;
				Id = id;
				AnnualCost = annualCost;
			}

			public int AnnualCost { get; }
			public string Id { get; }
			public string Name { get; }
		}

		public class Department
		{
			private readonly List<Employee> _staff = new List<Employee>();
			public Department(string name) => Name = name;
			public string Name { get; }

			public int GetTotalAnnualCost()
			{
				var result = 0;
				foreach (var employee in _staff)
					result += employee.AnnualCost;
				return result;
			}

			public int GetHeadCount() => _staff.Count;

			public void AddStaff(Employee arg)
			{
				_staff.Add(arg);
			}
		}
	}

	public class ExtractSuperclassAfter
	{
		public abstract class Party
		{
			protected Party(string name) => Name = name;

			public string Name { get; set; }
			public virtual int AnnualCost { get; set; }
		}

		public class Employee : Party
		{
			public Employee(string name, string id) : base(name)
			{
				Name = name;
				Id = id;
			}

			public string Id { get; }
		}

		public class Department : Party
		{
			private readonly List<Employee> _staff = new List<Employee>();
			private int _annualCost;

			public Department(string name) : base(name) => Name = name;

			public override int AnnualCost
			{
				get
				{
					foreach (var employee in _staff)
						_annualCost += employee.AnnualCost;
					return _annualCost;
				}
				set => _annualCost = value;
			}

			public int GetHeadCount() => _staff.Count;

			public void AddStaff(Employee arg)
			{
				_staff.Add(arg);
			}
		}
	}
}