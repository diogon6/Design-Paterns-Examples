using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	interface IDevice
	{
		void TurnOn();
		void TurnOff();
	}

	class Bulb : IDevice
	{
		public void TurnOn()
		{
			Console.WriteLine("Bulb has been lit");
		}

		public void TurnOff()
		{
			Console.WriteLine("Darkness!");
		}
	}

	interface ICommand
	{
		void Execute();
		void Undo();
		void Redo();
	}

	class TurnOn : ICommand
	{
		IDevice device;

		public TurnOn(IDevice device)
		{
			this.device = device;
		}

		public void Execute()
		{
			device.TurnOn();
		}

		public void Undo()
		{
			device.TurnOff();
		}

		public void Redo()
		{
			Execute();
		}
	}

	class TurnOff : ICommand
	{
		IDevice device;

		public TurnOff(IDevice device)
		{
			this.device = device;
		}

		public void Execute()
		{
			device.TurnOff();
		}

		public void Undo()
		{
			device.TurnOn();
		}

		public void Redo()
		{
			Execute();
		}
	}

	class Remote
	{
		public void Submit(ICommand command)
		{
			command.Execute();
		}

		public void SubmitUndo(ICommand command)
		{
			command.Undo();
		}

		public void SubmitRedo(ICommand command)
		{
			command.Redo();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			IDevice bulb = new Bulb();

			var bulbTurnOn = new TurnOn(bulb);
			var bulbTurnOff = new TurnOff(bulb);

			Remote remote = new Remote();

			remote.Submit(bulbTurnOn);
			//remote.SubmitUndo(bulbTurnOn);
			remote.Submit(bulbTurnOff);

			Console.ReadKey();
		}
	}
}
