using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
	interface IAnimal
	{
		void Accept(IAnimalOperation operation);
	}

	interface IAnimalOperation
	{
		void VisitLion(Lion lion);
		void VisitDolphin(Dolphin dolphin);
		void VisitMonkey(Monkey monkey);
	}

	class Speak : IAnimalOperation
	{
		public void VisitLion(Lion lion)
		{
			lion.Roar();
		}

		public void VisitDolphin(Dolphin dolphin)
		{
			dolphin.Speak();
		}

		public void VisitMonkey(Monkey monkey)
		{
			monkey.Shout();
		}
	}

	class Lion : IAnimal
	{
		public void Accept(IAnimalOperation operation)
		{
			operation.VisitLion(this);
		}

		public void Roar()
		{
			Console.WriteLine("Roar");
		}
	}

	class Dolphin : IAnimal
	{
		public void Accept(IAnimalOperation operation)
		{
			operation.VisitDolphin(this);
		}

		public void Speak()
		{
			Console.WriteLine("Speak");
		}
	}

	class Monkey : IAnimal
	{
		public void Accept(IAnimalOperation operation)
		{
			operation.VisitMonkey(this);
		}

		public void Shout()
		{
			Console.WriteLine("Shout");
		}
	}

	class Program
	{
		static void Main()
		{
			var monkey = new Monkey();
			var lion = new Lion();
			var dolphin = new Dolphin();

			var speak = new Speak();

			monkey.Accept(speak);    
			lion.Accept(speak);      
			dolphin.Accept(speak);

			Console.ReadKey();
		}
	}
}
