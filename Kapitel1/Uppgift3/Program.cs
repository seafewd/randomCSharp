using System;

namespace Uppgift3
{
	class Program
	{
		static void Main(string[] args)
		{
			Program main = new Program();

			int count = main.askForNumberOfIntegers();
			int[] integers = main.askForIntegers(count);
			main.reverseArray(integers);
			main.printIntegers(integers);

			Console.ReadLine();
		}

		private int askForNumberOfIntegers()
		{
			Console.Write("Enter the number of integers you wish to store: ");
			string input = Console.ReadLine();
			bool isNumber = Int32.TryParse(input, out int count);

			if (!isNumber) {
				Console.WriteLine("Please enter an integer number.");
				askForNumberOfIntegers();
			}

			return count;
		}

		private int[] askForIntegers(int count)
		{
			int[] integers = new int[count];

			Console.WriteLine("Please enter {0} integers:", count);
			for (int i = 0; i < count; i++)
			{
				string input = Console.ReadLine();
				bool isNumber = Int32.TryParse(input, out int number);
				if (!isNumber)
				{
					Console.WriteLine("Please enter only integer numbers.");
					askForIntegers(count);
				}
				integers[i] = number;
			}
			return integers;
		}

		private void printIntegers(int[] integers)
		{
			Console.WriteLine("Your numbers printed in reverse:");
			foreach (int i in integers)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
		}

		private int[] reverseArray(int[] array)
		{
			for (int i = 0; i < array.Length/2; i++)
			{
				reverseArrayAux(array, i, array.Length - i - 1);
			}
			return array;
		}

		private void reverseArrayAux(int[] array, int i, int j)
		{
			int temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}
