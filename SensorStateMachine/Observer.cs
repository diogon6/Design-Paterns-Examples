﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorStateMachine
{
	interface IObserver
	{
		void Update(string text);
	}

	class Monitor : IObserver
	{
		public void Update(string text)
		{
			Console.WriteLine(text);
		}
	}

	interface IObservable
	{
		void AddObserver(IObserver observer);
		void RemoveObserver(IObserver observer);
		void Notify();
	}
}
