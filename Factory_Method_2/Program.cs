using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_2
{
	interface IDoor
	{
		void GetDetails();
	}

	class WoodenDoor : IDoor
	{
		public void GetDetails()
		{
			Console.WriteLine("I'm a wooden door");
		}
	}

	class IronDoor : IDoor
	{
		public void GetDetails()
		{
			Console.WriteLine("I'm a iron door");
		}
	}

	abstract class Factory
	{
		public abstract IDoor MakeDoor(string type);
	}

	class ConcreteFactory : Factory
	{
		public override IDoor MakeDoor(string type)
		{
			if (type == "WoodenDoor")
				return new WoodenDoor();
			if (type == "IronDoor")
				return new IronDoor();

			throw new ApplicationException();

		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Factory factory = new ConcreteFactory();
			IDoor irondoor = factory.MakeDoor("IronDoor");
			IDoor woodendoor = factory.MakeDoor("WoodenDoor");

			irondoor.GetDetails();
			woodendoor.GetDetails();

			Console.ReadKey();
		}
	}
}
