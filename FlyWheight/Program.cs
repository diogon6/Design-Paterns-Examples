using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
	class Tea
	{
		public Tea() { }
	}

	class TeaMaker
	{
		 readonly Dictionary<string, Tea> AvaiableTea = new Dictionary<string, Tea>();

		public Tea MakeTea(string preference)
		{
			if (!AvaiableTea.ContainsKey(preference))
				AvaiableTea[preference] = new Tea();
			return AvaiableTea[preference];
		}
	}

	class TeaShop
	{
		TeaMaker teamaker = new TeaMaker();

		public void takeOrder(int table, string preference)
		{
			Tea order = teamaker.MakeTea(preference);
			System.Console.WriteLine("Serving " + preference + " tea to table " + table);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			TeaShop teashop = new TeaShop();

			teashop.takeOrder(1, "no sugar");
			teashop.takeOrder(2, "hot");

			System.Console.ReadLine();
		}
	}
}
