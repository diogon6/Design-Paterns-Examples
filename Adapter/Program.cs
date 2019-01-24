using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
	public interface ILion
	{
		void roar();
	}

	public class AfricanLion : ILion
	{
		public void roar()
		{
			System.Console.WriteLine("Roars in african.");
		}
	}

	public class AsianLion : ILion
	{
		public void roar()
		{
			System.Console.WriteLine("Roars in asian.");
		}
	}

	class WildDog
	{
		public void bark()
		{
			System.Console.WriteLine("Bark");
		}
	}

	class WildDogAdapter : ILion
	{
		WildDog wilddog;

		public WildDogAdapter(WildDog dog)
		{
			this.wilddog = dog;
		}

		public void roar()
		{
			wilddog.bark();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<ILion> lions = new List<ILion>();
			lions.Add(new AfricanLion());
			lions.Add(new AsianLion());
			lions.Add(new WildDogAdapter(new WildDog()));

			foreach (ILion leao in lions)
				leao.roar();

			System.Console.ReadLine();
		}
	}
}
