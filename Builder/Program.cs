using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
	class Burger
	{
		public int size = 0;
		public bool cheese;
		public bool ketchup;
		public bool sauce;

		public Burger(BurgerBuilder builder)
		{
			this.size = builder.size;
			this.cheese = builder.cheese;
			this.ketchup = builder.ketchup;
			this.sauce = builder.sauce;
		}

		public void GetDescription()
		{
			Console.WriteLine("Size: " + this.size);
			Console.WriteLine("Cheese: " + this.cheese);
			Console.WriteLine("Ketchup: " + this.ketchup);
			Console.WriteLine("Sauce: " + this.sauce);
		}
	}

	class BurgerBuilder
	{
		public int size = 0;
		public bool cheese;
		public bool ketchup;
		public bool sauce;

		public BurgerBuilder(int size)
		{
			this.size = size;
		}

		public BurgerBuilder AddCheese()
		{
			this.cheese = true;
			return this;
		}

		public BurgerBuilder AddKetchup()
		{
			this.ketchup = true;
			return this;
		}

		public BurgerBuilder AddSauce()
		{
			this.sauce = true;
			return this;
		}

		public Burger Build()
		{
			return new Burger(this);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var burger = new BurgerBuilder(4).AddCheese()
											 .AddSauce()
											 .Build();
			burger.GetDescription();
			Console.ReadKey();
		}
	}
}
