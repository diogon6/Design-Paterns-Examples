using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
	abstract class Builder
	{
		public void Build()
		{
			Test();
			Lint();
			Assemble();
			Deploy();
			Testing();
		}

		abstract public void Test();
		abstract public void Lint();
		abstract public void Assemble();
		abstract public void Deploy();

		public virtual void Testing()
		{
			Console.WriteLine("This is the original test");
		}
	}

	class Android : Builder
	{
		public override void Test()
		{
			Console.WriteLine("Testing on Android");
		}

		public override void Lint()
		{
			Console.WriteLine("Linting on Android");
		}

		public override void Assemble()
		{
			Console.WriteLine("Assembling on Android");
		}

		public override void Deploy()
		{
			Console.WriteLine("Deploying on Android");
		}
	}

	class IOS : Builder
	{
		public override void Test()
		{
			Console.WriteLine("Testing on IOS");
		}

		public override void Lint()
		{
			Console.WriteLine("Linting on IOS");
		}

		public override void Assemble()
		{
			Console.WriteLine("Assembling on IOS");
		}

		public override void Deploy()
		{
			Console.WriteLine("Deploying on IOS");
		}

		public override void Testing()
		{
			Console.WriteLine("This is the changed test");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Android android = new Android();
			IOS ios = new IOS();

			android.Build();
			ios.Build();

			Console.ReadKey();
		}
	}
}
