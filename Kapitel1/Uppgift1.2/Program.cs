using System;
using System.Globalization;

namespace Uppgift1._2
{
	class Program
	{
		static void Main(string[] args)
		{
			Program main = new Program();

			// get cost of the purchase
			double cost = main.inputCost();
			// get amount received from customer
			double received = main.inputAmountReceived();
			// calculate change
			double change = received - cost;

			// if customer doesn't have enough money the transaction doesn't make sense. abort
			if (change < 0)
			{
				Console.WriteLine("Customer doesn't have enough money for this purchase.");
				return;
			}

			Console.WriteLine("\nChange: {0} kr", change);
			// print the change in bills of 1000, 500, 100 etc.
			main.printChange(change);
		}

		/// <summary>
		/// Get cost of purchase using method to verify input
		/// </summary>
		/// <returns>Cost as double</returns>
		private double inputCost()										
		{
			Console.Write("Enter cost: ");
			double cost = verifyInput();
			cost = Math.Ceiling(cost * 2) / 2;							// round up to nearest 50 cents
			Console.WriteLine(cost);
			return cost;
		}

		/// <summary>
		/// Get amount received using method to verify input
		/// </summary>
		/// <returns>Amount received as double</returns>
		private double inputAmountReceived()								
		{
			Console.Write("Enter amount received: ");
			return verifyInput();
		}

		/// <summary>
		/// Verify user's input by checking if it's parsable
		/// </summary>
		/// <returns>Result as float</returns>
		private double verifyInput()
		{
			double result = 0d;
			// loop until input is acceptable
			while (true)
			{
				try
				{
					string input = Console.ReadLine();
					// try to parse user input and see if it's a valid float number
					result = double.Parse(input, CultureInfo.InvariantCulture);
					break;
				}
				catch (FormatException)
				{
					Console.WriteLine("Please use only numbers and decimal signs (0-9 and . or ,)");
				}
			}
			return result;
		}

		/// <summary>
		/// Print the change that the user gets back in bills of 1000, 500, 100, 20 and 5, 1 and 50 cent coins
		/// </summary>
		/// <param name="change">Change</param>
		private void printChange(double change)
		{
			// divide change by 1000 to get the amount of 1000-bills
			int thousandBills = (int)change / 1000;
			// update value of change by subtracting the number of 1000 bills times 1000
			change -= 1000 * thousandBills;
			// etc...
			int fiveHundredbills = (int)change / 500;
			change -= 500 * fiveHundredbills;
			int hundredBills = (int)change / 100;
			change -= 100 * hundredBills;
			int twentyBills = (int)change / 20;
			change -= 20 * twentyBills;
			int fiveCrowns = (int)change / 5;
			change -= 5 * fiveCrowns;
			int oneCrowns = (int)change / 1;
			change -= 1 * oneCrowns;

			// only print the amount of bills and coins if it makes sense
			if (thousandBills != 0)
				Console.WriteLine(" 1000-bills: {0}", thousandBills);
			if (fiveHundredbills != 0)
				Console.WriteLine("  500-bills: {0}", fiveHundredbills);
			if (hundredBills != 0)
				Console.WriteLine("  100-bills: {0}", hundredBills);
			if (twentyBills != 0)
				Console.WriteLine("   20-bills: {0}", twentyBills);
			if (fiveCrowns != 0)
				Console.WriteLine("   5-crowns: {0}", fiveCrowns);
			if (oneCrowns != 0)
				Console.WriteLine("   1-crowns: {0}", oneCrowns);
			if (change != 0)
				Console.WriteLine("   50-cents: {0}", 1);

		}
	}
}
