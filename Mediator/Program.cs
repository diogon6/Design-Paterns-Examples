using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
	interface IChatRoomMediator
	{
		void ShowMessage(string user, string message);
	}

	class ChatRoom : IChatRoomMediator
	{
		public void ShowMessage(string user, string message)
		{
			Console.WriteLine(user + " - " + message);
		}
	}

	class User
	{
		IChatRoomMediator mchatroom;
		string mname;

		public User(string name, IChatRoomMediator chatroom)
		{
			mname = name;
			mchatroom = chatroom;
		}

		public string GetName()
		{
			return mname;
		}

		public void SendMessage(string message)
		{
			mchatroom.ShowMessage(mname, message);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			IChatRoomMediator chat = new ChatRoom();

			User john = new User("john", chat);
			User sarah = new User("sarah", chat);

			john.SendMessage("Hi");
			sarah.SendMessage("Hey, what's up?");

			Console.ReadKey();
		}
	}
}
