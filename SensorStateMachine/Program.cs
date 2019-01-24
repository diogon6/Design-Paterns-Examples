using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorStateMachine
{
	interface IState
	{
		void exit();
		void End();
		void Begin();
		void Resume();
		void Pause();
	}

	class Inactive : IState
	{
		Sensor mSensor;

		public Inactive(Sensor sensor)
		{
			mSensor = sensor;
		}

		public void exit()
		{
			Console.WriteLine("Exiting...");
			mSensor.SetState("Exit");
		}

		public void End() { }

		public void Begin()
		{
			Console.WriteLine("Beginning...");
			mSensor.SetState("Active");
		}

		public void Resume() { }
		public void Pause() { }
	}

	class Exit : IState
	{
		Sensor mSensor;

		public Exit(Sensor sensor)
		{
			mSensor = sensor;
		}

		public void exit() { }
		public void End() { }
		public void Begin() { }
		public void Resume() { }
		public void Pause() { }
	}

	class Active : IState
	{
		Sensor mSensor;

		public Active(Sensor sensor)
		{
			mSensor = sensor;
		}

		public void exit() { }
		public void End()
		{
			Console.WriteLine("Ending...");
			mSensor.SetState("Inactive");
		}
		public void Begin() { }
		public void Resume() { }
		public void Pause()
		{
			Console.WriteLine("Pausing...");
			mSensor.SetState("Paused");
		}
	}

	class Paused : IState
	{
		Sensor mSensor;

		public Paused(Sensor sensor)
		{
			mSensor = sensor;
		}

		public void exit() { }
		public void End()
		{
			Console.WriteLine("Ending...");
			mSensor.SetState("Inactive");
		}
		public void Begin() { }
		public void Resume()
		{
			Console.WriteLine("Resuming...");
			mSensor.SetState("Active");
		}
		public void Pause() { }
	}

	class Sensor : IObservable
	{
		Dictionary<string, IState> states = new Dictionary<string, IState>();
		IState current;
		List<IObserver> observers = new List<IObserver>();

		public Sensor()
		{
			states.Add("Inactive", new Inactive(this));
			states.Add("Exit", new Exit(this));
			states.Add("Active", new Active(this));
			states.Add("Paused", new Paused(this));

			current = states["Inactive"];
		}

		public void SetState(string newState)
		{
			current = states[newState];
			Notify();
		}

		public void exit() { current.exit(); }

		public void End() { current.End(); }

		public void Begin() { current.Begin(); }

		public void Resume() { current.Resume(); }

		public void Pause() { current.Pause(); }

		public void AddObserver(IObserver observer)
		{
			if (!observers.Contains(observer))
				observers.Add(observer);
		}

		public void RemoveObserver(IObserver observer)
		{
			if (observers.Contains(observer))
				observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var obs in observers)
				obs.Update("Change of state");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Sensor sensor = new Sensor();
			IObserver monitor = new Monitor();

			sensor.AddObserver(monitor);

			sensor.Begin();
			sensor.Pause();
			sensor.Resume();
			sensor.Pause();
			sensor.End();
			sensor.exit();
			sensor.Begin();

			Console.ReadKey();
		}
	}
}
