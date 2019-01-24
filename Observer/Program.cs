using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
	interface IObserver
	{
		void update(double value);
	}

	class Monitor : IObserver
	{
		public void update(double value)
		{
			System.Console.WriteLine("New value received: " + value);
		}
	}

	interface IObservable
	{
		void registerObserver(IObserver observer);
		void notifyObservers();
		void removeObserver(IObserver observer);
	}

	class Sensor : IObservable
	{
		List<IObserver> observers = new List<IObserver>();
		double value;

		public Sensor(double v)
		{
			value = v;
		}

		public void setValue(double v)
		{
			value = v;
			notifyObservers();
		}

		public void notifyObservers()
		{
			foreach (IObserver observer in observers)
				observer.update(value);
		}

		public void registerObserver(IObserver observer)
		{
			if (!observers.Contains(observer))
				observers.Add(observer);
		}

		public void removeObserver(IObserver observer)
		{
			if (observers.Contains(observer))
				observers.Remove(observer);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Sensor sensor = new Sensor(1.5);
			IObserver monitor = new Monitor();

			sensor.registerObserver(monitor);
			sensor.setValue(5.1);

			System.Console.ReadLine();
		}
	}
}
