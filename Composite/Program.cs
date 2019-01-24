using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
	interface IEmployee
	{
		int GetSalary();
		string GetRole();
		string GetName();
	}

	class Developer : IEmployee
	{
		int msalary;
		string mname;

		public Developer(int salary, string name)
		{
			this.msalary = salary;
			this.mname = name;
		}

		public int GetSalary()
		{
			return msalary;
		}

		public string GetRole()
		{
			return "Developer";
		}

		public string GetName()
		{
			return mname;
		}
	}

	class Designer : IEmployee
	{
		int msalary;
		string mname;

		public Designer(int salary, string name)
		{
			this.msalary = salary;
			this.mname = name;
		}

		public int GetSalary()
		{
			return msalary;
		}

		public string GetRole()
		{
			return "Designer";
		}

		public string GetName()
		{
			return mname;
		}
	}

	class Organization
	{
		List<IEmployee> employees;

		public Organization()
		{
			employees = new List<IEmployee>();
		}

		public void AddEmployee(IEmployee employee)
		{
			employees.Add(employee);
		}

		public float GetNetSalaries()
		{
			float netSalary = 0;

			foreach (var e in employees)
			{
				netSalary += e.GetSalary();
			}
			return netSalary;
		}
	}

	class Program
	{
		static void Main()
		{
			var dev = new Developer(50, "john");
			var des = new Designer(40, "sarah");
			var org = new Organization();

			org.AddEmployee(dev);
			org.AddEmployee(des);
			Console.WriteLine(org.GetNetSalaries());

			Console.ReadKey();
		}
	}
}
