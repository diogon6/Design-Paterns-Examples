using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
	interface ICoffee
	{
		float GetCost();
		string GetDetails();
	}

	class Coffee : ICoffee
	{
		public Coffee()
		{

		}

		public float GetCost()
		{
			return 0.65f;
		}

		public string GetDetails()
		{
			return "Coffee";
		}
	}

	class Sugar : ICoffee
	{
		ICoffee coffee;

		public Sugar(ICoffee coffee)
		{
			this.coffee = coffee;
		}

		public float GetCost()
		{
			return coffee.GetCost() + 0.05f;
		}

		public string GetDetails()
		{
			return coffee.GetDetails() + " + Sugar";
		}
	}

	class Whipp : ICoffee
	{
		ICoffee coffee;

		public Whipp (ICoffee coffee)
		{
			this.coffee = coffee;
		}

		public float GetCost()
		{
			return coffee.GetCost() + 0.20f;
		}

		public string GetDetails()
		{
			return coffee.GetDetails() + " + Whipp";
		}
	}

	class Milk : ICoffee
	{
		ICoffee beverage;

		public Milk(ICoffee bev)
		{
			beverage = bev;
		}

		public float GetCost()
		{
			return beverage.GetCost() + 0.15f;
		}

		public string GetDetails()
		{
			return beverage.GetDetails() + " + Milk";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			ICoffee coffee = new Coffee();
			coffee = new Sugar(coffee);
			coffee = new Sugar(coffee);
			coffee = new Sugar(coffee);
			coffee = new Whipp(coffee);
			coffee = new Milk(coffee);

			Console.WriteLine("Details: " + coffee.GetDetails());
			Console.WriteLine("Cost: " + coffee.GetCost());

			Console.ReadKey();
		}
	}
}
