using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
	interface IDoor
	{
		void Open();
		void Close();
	}

	class LabDoor : IDoor
	{
		public void Open()
		{
			Console.WriteLine("Openning lab door...");
		}

		public void Close()
		{
			Console.WriteLine("Closing lab door...");
		}
	}

	class SecuredDoor
	{
		IDoor door;

		public SecuredDoor(IDoor door)
		{
			this.door = door;
		}

		public void Open(string password)
		{
			if (password == "secret")
				door.Open();
			else
				Console.WriteLine("Wrong password");
		}

		public void Close()
		{
			door.Close();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			IDoor labdoor = new LabDoor();
			SecuredDoor securedoor = new SecuredDoor(labdoor);
			securedoor.Open("random");
			securedoor.Open("secret");
			securedoor.Close();

			Console.ReadKey();
		}
	}
}
