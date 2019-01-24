using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
	class Computer
	{
		public void GetElectricShock()
		{
			Console.Write("Ouch!");
		}

		public void MakeSound()
		{
			Console.Write("Beep beep!");
		}

		public void ShowLoadingScreen()
		{
			Console.Write("Loading..");
		}

		public void Bam()
		{
			Console.Write("Ready to be used!");
		}

		public void CloseEverything()
		{
			Console.Write("Bup bup bup buzzzz!");
		}

		public void Sooth()
		{
			Console.Write("Zzzzz");
		}

		public void PullCurrent()
		{
			Console.Write("Haaah!");
		}
	}

	class ComputerFacade
	{
		Computer mComputer;

		public ComputerFacade(Computer computer)
		{
			this.mComputer = computer;
		}

		public void TurnOn()
		{
			mComputer.GetElectricShock();
			mComputer.MakeSound();
			mComputer.ShowLoadingScreen();
			mComputer.Bam();
		}

		public void TurnOff()
		{
			mComputer.CloseEverything();
			mComputer.PullCurrent();
			mComputer.Sooth();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Computer comp = new Computer();
			ComputerFacade cf = new ComputerFacade(comp);
			cf.TurnOn();
			cf.TurnOff();

			Console.ReadKey();
		}
	}
}
