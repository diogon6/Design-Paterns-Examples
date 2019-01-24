using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
	interface IDoor
	{
		void GetDetails();
	}

	class WoodenDoor : IDoor
	{
		public void GetDetails()
		{
			Console.WriteLine("It's a wooden door");
		}
	}

	class IronDoor : IDoor
	{
		public void GetDetails()
		{
			Console.WriteLine("It's an iron door");
		}
	}

	interface IExpert
	{
		void GetDetails();
	}

	class Carpenter : IExpert
	{
		public void GetDetails()
		{
			Console.WriteLine("It's a carpenter");
		}
	}

	class Welder : IExpert
	{
		public void GetDetails()
		{
			Console.WriteLine("It's a welder");
		}
	}

	interface IDoorFactory
	{
		IDoor MakeDoor();
		IExpert GetExpert();
	}

	class WoodenDoorFactory : IDoorFactory
	{
		public IDoor MakeDoor()
		{
			return new WoodenDoor();
		}

		public IExpert GetExpert()
		{
			return new Carpenter();
		}
	}

	class IronDoorFactory : IDoorFactory
	{
		public IDoor MakeDoor()
		{
			return new IronDoor();
		}

		public IExpert GetExpert()
		{
			return new Welder();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			IDoorFactory woodenfactory = new WoodenDoorFactory();
			IDoorFactory ironfactory = new IronDoorFactory();

			var woodendoor = woodenfactory.MakeDoor();
			var carpenter = woodenfactory.GetExpert();

			var irondoor = ironfactory.MakeDoor();
			var welder = ironfactory.GetExpert();

			woodendoor.GetDetails();
			carpenter.GetDetails();

			irondoor.GetDetails();
			welder.GetDetails();

			Console.ReadKey();
		}
	}
}
