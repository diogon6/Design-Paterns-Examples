using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
	class Memento
	{
		string text;

		public Memento(string s)
		{
			text = s;
		}

		public string GetContent()
		{
			return text;
		}
	}

	class Editor
	{
		Memento memento;
		string text;

		public Editor()
		{
			text = "";
			memento = new Memento("");
		}

		public void Type(string typing)
		{
			text += "\n" + typing;
		}

		public void Save()
		{
			memento = new Memento(text);
		}

		public void Restore()
		{
			text = memento.GetContent();
		}

		public string GetText()
		{
			return text;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var editor = new Editor();

			editor.Type("This is the first sentence.");
			editor.Type("This is second.");

			editor.Save();

			editor.Type("This is third.");

			Console.WriteLine(editor.GetText());

			editor.Restore();

			Console.Write(editor.GetText());

			Console.ReadKey();
		}
	}
}
