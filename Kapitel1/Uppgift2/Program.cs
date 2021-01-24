using System;

namespace Uppgift2
{
	class Program
	{
		/// <summary>
		/// Nested loop to generate a 16x32 matrix
		/// </summary>
		static void Main(string[] args)
		{
			for (int i = 0; i < 16; i++)			// loop 16 times to generate 16 rows
			{
				if (i % 2 != 0)						// if the row number is odd we add a space in the start of the line
					Console.Write(" ");

				for (int j = 0; j < 32; j++)		// loop 32 times to generate 32 columns
				{
					Console.Write("* ");			// for each iteration add "* "
				}
				
				Console.WriteLine();				// new line for each iteration of i (row)
			}
		}
	}
}
