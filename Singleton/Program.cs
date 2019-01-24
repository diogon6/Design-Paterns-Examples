using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
	class President
	{
		static President instance;

		private President()
		{

		}

		public static President GetInstance()
		{
			if (instance == null)
				instance = new President();

			return instance;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			President a = President.GetInstance();
			President b = President.GetInstance();

			System.Console.Write(a == b);
			System.Console.Read();
		}
	}
}
