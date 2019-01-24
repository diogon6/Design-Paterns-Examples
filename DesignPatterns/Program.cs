using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Factory
{
	public interface IDoor
	{
		int getWidth();
		int getHeight();
	}

	public class WoodenDoor : IDoor
	{
		private int height;
		private int width;

		public WoodenDoor(int height, int width)
		{
			this.height = height;
			this.width = width;
		}

		public int getWidth()
		{
			return width;
		}

		public int getHeight()
		{
			return height;
		}
	}

	public class DoorFactory
	{
		public IDoor makeDoor(int height, int width)
		{
			return new WoodenDoor(height, width);
		}
	}
		


	class Program
	{
		static void Main(string[] args)
		{
			DoorFactory factory = new DoorFactory();
			IDoor door = factory.makeDoor(80, 20);
			System.Console.WriteLine("Height: " + door.getHeight());
			System.Console.WriteLine("Width: " + door.getWidth());
			System.Console.ReadKey();
		}
	}
}
