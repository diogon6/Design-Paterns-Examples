using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
	interface IWrite
	{
		void Write(string text);
	}

	class UpperCase : IWrite
	{
		public void Write(string text)
		{
			Console.WriteLine(text.ToUpper());
		}
	}

	class LowerCase : IWrite
	{
		public void Write(string text)
		{
			Console.WriteLine(text.ToLower());
		}
	}

	class Default : IWrite
	{
		public void Write(string text)
		{
			Console.WriteLine(text);
		}
	}

	class TextEditor
	{
		private IWrite mState;

		public TextEditor()
		{
			mState = new Default();
		}

		public void SetState(IWrite state)
		{
			mState = state;
		}

		public void Typing(string text)
		{
			mState.Write(text);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			TextEditor editor = new TextEditor();
			editor.Typing("First Line");
			editor.SetState(new UpperCase());
			editor.Typing("Second Line");
			editor.SetState(new LowerCase());
			editor.Typing("Third Line");

			Console.ReadKey();
		}
	}
}
