using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
	interface ISort
	{
		void Sort();
	}

	class BubbleSort : ISort
	{
		public void Sort()
		{
			Console.WriteLine("Using bubble sort");
		}
	}

	class QuickSort : ISort
	{
		public void Sort()
		{
			Console.WriteLine("Using quick sort");
		}
	}

	class Sorter
	{
		private ISort msort;

		public Sorter(ISort sort)
		{
			this.msort = sort;
		}

		public void Sort()
		{
			msort.Sort();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			ISort quicksort = new QuickSort();
			ISort bubblesort = new BubbleSort();

			Sorter sorter = new Sorter(quicksort);
			sorter.Sort();

			Sorter sorter2 = new Sorter(bubblesort);
			sorter2.Sort();

			Console.ReadKey();
		}
	}
}
