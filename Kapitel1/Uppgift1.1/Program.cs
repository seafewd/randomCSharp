using System;

namespace Uppgift1._1
{
	class Program
	{
		static void Main(string[] args)
		{
			Program main = new Program();

			while (true)																									// run loop until user types "exit"
			{
				int[] randomIntegers = main.generateIntegers(10000);														// store 10000 randomly generated integers in array
				int firstInt = 2;																							// first integer to check
				int secondInt = 9;																							// second integer to check
				int totalIntegers = main.countNumbers(randomIntegers, firstInt, secondInt);									// count the number of occurences of the above integers
				Console.WriteLine("Generated {0} random integers.", randomIntegers.Length);
				Console.WriteLine("Found {0} occurences of integers {1} and {2}.\n", totalIntegers, firstInt, secondInt);

				Console.WriteLine("Type \"exit\" to quit. Press Enter to try again.");
				string input = Console.ReadLine();
				if (input.ToLower() == "exit")																				// break loop if user types exit
					break;
			}
			
		}

		/// <summary>
		/// Generate array of n randomly generated integers
		/// </summary>
		/// <param name="n">Number of integers to generate</param>
		/// <returns>Array of randomly generated integers</returns>
		private int[] generateIntegers(int n)
		{
			Random rand = new Random();
			int[] integers = new int[n];

			for (int i = 0; i < n; i++)
			{
				integers[i] = rand.Next(0, 9);
			}

			return integers;
		}

		/// <summary>
		/// Count the number of occurences in the array of type i and j
		/// </summary>
		/// <param name="array">Array to iterate through</param>
		/// <param name="i">First number</param>
		/// <param name="j">Second number</param>
		/// <returns>Amount of integers corresponding to types i and j</returns>
		private int countNumbers(int[] array, int i, int j)
		{
			int firstNumberCount = 0;
			int secondNumberCount = 0;
			foreach (int n in array)
			{
				if (n == i)
					firstNumberCount++;
				else if (n == j)
					secondNumberCount++;
			}
			return firstNumberCount + secondNumberCount;
		}
	}
}
