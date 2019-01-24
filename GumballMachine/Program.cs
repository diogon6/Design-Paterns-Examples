using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachine
{
	interface IState
	{
		void Refill();
		void TurnsCrank();
		void InsertsQuarter();
		void EjectQuarter();
		void DispenseGumball();
	}

	class SoldOut : IState
	{
		GumballMachine machine;

		public SoldOut(GumballMachine mach)
		{
			machine = mach;
		}

		public void Refill()
		{
			machine.AddGumballs();
			machine.SetState("NoQuarter");
			Console.WriteLine("Refilling...");
		}

		public void TurnsCrank()
		{
			Console.WriteLine("You can't turn the crank right now");
		}

		public void InsertsQuarter()
		{
			Console.WriteLine("You can't insert a quarter right now");
		}

		public void EjectQuarter()
		{
			Console.WriteLine("You can't eject the quarter right now");
		}

		public void DispenseGumball()
		{
			Console.WriteLine("You can't dispense a gumball right now");
		}
	}

	class NoQuarter : IState
	{
		GumballMachine machine;

		public NoQuarter(GumballMachine mach)
		{
			machine = mach;
		}

		public void Refill()
		{
			Console.WriteLine("You can't refill right now");
		}

		public void TurnsCrank()
		{
			Console.WriteLine("You can't turn the crank right now");
		}

		public void InsertsQuarter()
		{
			Console.WriteLine("Quarter inserted");
			machine.SetState("HasQuarter");
		}

		public void EjectQuarter()
		{
			Console.WriteLine("You can't eject the quarter right now");
		}

		public void DispenseGumball()
		{
			Console.WriteLine("You can't dispense right now");
		}
	}

	class HasQuarter : IState
	{
		GumballMachine machine;

		public HasQuarter(GumballMachine mach)
		{
			machine = mach;
		}

		public void Refill()
		{
			Console.WriteLine("You can't refill right now");
		}

		public void TurnsCrank()
		{
			machine.SetState("GumballSold");
			Console.WriteLine("Processing purchase");
			machine.removeGumball();
			Console.WriteLine("Gumball sold");
		}

		public void InsertsQuarter()
		{
			Console.WriteLine("You can't insert a quarter right now");
		}

		public void EjectQuarter()
		{
			machine.SetState("NoQuarter");
			Console.WriteLine("Purchase cancelled. Here's your quarter back");
		}

		public void DispenseGumball()
		{
			Console.WriteLine("You cant dispense right now");
		}
	}

	class GumballSold : IState
	{
		GumballMachine machine;

		public GumballSold(GumballMachine mach)
		{
			machine = mach;
		}

		public void Refill()
		{
			Console.WriteLine("You can't refill right now");
		}

		public void TurnsCrank()
		{
			Console.WriteLine("You can't turn the crank right now");
		}

		public void InsertsQuarter()
		{
			Console.WriteLine("You can't insert a quarter right now");
		}

		public void EjectQuarter()
		{
			Console.WriteLine("You can't eject a quarter right now");
		}

		public void DispenseGumball()
		{
			if (machine.GetGumballs() > 0)
				machine.SetState("NoQuarter");
			else
				machine.SetState("SoldOut");
		}
	}

	class GumballMachine
	{
		Dictionary<string, IState> states = new Dictionary<string, IState>();
		IState currentState;
		int mgumballs = 0;
		int refillAmount = 5;

		public GumballMachine(int gumballs)
		{
			states.Add("SoldOut", new SoldOut(this));
			states.Add("NoQuarter", new NoQuarter(this));
			states.Add("HasQuarter", new HasQuarter(this));
			states.Add("GumballSold", new GumballSold(this));

			mgumballs = gumballs;

			if (mgumballs > 0)
				currentState = states["NoQuarter"];
			else
				currentState = states["SoldOut"];
		}

		public void Refill()
		{
			currentState.Refill();
		}

		public void TurnsCrank()
		{
			currentState.TurnsCrank();
		}

		public void InsertsQuarter()
		{
			currentState.InsertsQuarter();
		}

		public void EjectQuarter()
		{
			currentState.EjectQuarter();
		}

		public void DispenseGumball()
		{
			currentState.DispenseGumball();
		}

		public void AddGumballs()
		{
			mgumballs += refillAmount;
		}

		public int GetGumballs()
		{
			return mgumballs;
		}

		public void removeGumball()
		{
			mgumballs--;
		}

		public void SetState(string state)
		{
			currentState = states[state];
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			GumballMachine machine = new GumballMachine(2);
			machine.InsertsQuarter();
			machine.TurnsCrank();
			machine.DispenseGumball();
			machine.InsertsQuarter();
			machine.EjectQuarter();
			machine.InsertsQuarter();
			machine.InsertsQuarter();
			machine.TurnsCrank();
			machine.DispenseGumball();
			machine.InsertsQuarter();
			machine.TurnsCrank();
			machine.DispenseGumball();
			machine.Refill();
			machine.InsertsQuarter();
			machine.TurnsCrank();
			machine.DispenseGumball();
			machine.InsertsQuarter();
			machine.EjectQuarter();
			machine.InsertsQuarter();
			machine.InsertsQuarter();
			machine.TurnsCrank();
			machine.DispenseGumball();

			Console.ReadKey();
		}
	}
}
