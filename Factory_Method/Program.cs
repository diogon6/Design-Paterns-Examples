using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
	public interface IInterviewer
	{
		void askQuestions();
	}

	public class Developer : IInterviewer
	{
		public void askQuestions()
		{
			System.Console.WriteLine("Ask about DIS");
		}
	}

	public class Executive : IInterviewer
	{
		public void askQuestions()
		{
			System.Console.WriteLine("Ask about something else");
		}
	}

	public abstract class HiringManager
	{
		public abstract IInterviewer makeInterviewer();

		public void TakeInterview()
		{
			var interviewer = this.makeInterviewer();
			interviewer.askQuestions();
		}
	}

	public class DeveloperManager : HiringManager
	{
		public override IInterviewer makeInterviewer()
		{
			return new Developer();
		}
	}

	public class ExecutiveManager : HiringManager
	{
		public override IInterviewer makeInterviewer()
		{
			return new Executive();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			HiringManager developer = new DeveloperManager();
			HiringManager executive = new ExecutiveManager();

			developer.TakeInterview();
			executive.TakeInterview();

			System.Console.ReadKey();
		}
	}
}
