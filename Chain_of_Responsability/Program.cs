using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsability
{
	abstract class Account
	{
		protected double mBalance;
		private Account mSuccessor;

		public void SetNext(Account account)
		{
			this.mSuccessor = account;
		}

		public void Pay(double amount)
		{
			if (this.mBalance >= amount)
				Console.WriteLine("Paid " + amount + " using " + this.GetName());
			else
			{
				if (mSuccessor != null)
					mSuccessor.Pay(amount);
				else
					Console.WriteLine("None of the payment options has enough credit!");
			}
		}

		abstract public string GetName();
	}

	class Bank : Account
	{
		public Bank(double balance)
		{
			this.mBalance = balance;
		}

		public override string GetName()
		{
			return "Bank";
		}
	}

	class Paypal : Account
	{
		public Paypal(double balance)
		{
			this.mBalance = balance;
		}

		public override string GetName()
		{
			return "Paypal";
		}
	}

	class Bitcoin : Account
	{
		public Bitcoin(double balance)
		{
			this.mBalance = balance;
		}

		public override string GetName()
		{
			return "Bitcoin";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Bank bank = new Bank(200);
			Paypal paypal = new Paypal(400);
			Bitcoin bitcoin = new Bitcoin(600);

			bank.SetNext(paypal);
			paypal.SetNext(bitcoin);

			bank.Pay(500);

			Console.ReadKey();
		}
	}
}
