using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
	interface IMenu
	{
		void GetDetails();
	}

	class About : IMenu
	{
		protected ITheme mtheme;

		public About(ITheme theme)
		{
			this.mtheme = theme;
		}

		public void GetDetails()
		{
			System.Console.WriteLine(mtheme.GetColor());
		}
	}

	class Careers : IMenu
	{
		protected ITheme mtheme;

		public Careers(ITheme theme)
		{
			this.mtheme = theme;
		}

		public void GetDetails()
		{
			System.Console.WriteLine(mtheme.GetColor());
		}
	}


	interface ITheme
	{
		string GetColor();
	}

	class Dark : ITheme
	{
		public string GetColor()
		{
			return "Dark";
		}
	}

	class Light : ITheme
	{
		public string GetColor()
		{
			return "Light";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var dark = new Dark();
			var light = new Light();

			var about = new About(dark);
			var careers = new Careers(light);

			about.GetDetails();
			careers.GetDetails();

			Console.ReadKey();
		}
	}
}
