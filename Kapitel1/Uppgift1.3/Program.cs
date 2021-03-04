using System;

namespace Uppgift1._3
{
	class Program
	{
		static void Main(string[] args)
		{
			Program main = new Program();

			main.printTemperatureTable(2);
		}

		/// <summary>
		/// Print a table of actual temperatures vs. effective temperatures
		/// </summary>
		private void printTemperatureTable(int increments)
		{
			// wind speed label
			string windSpeedLabel = "  Wind (m/s)                     ";

			// print out table header with max and min values along with increment
			printHeader(10, -30, increments);

			// loop through in order to print all values
			// todo: change to variable values
			for (int i = 2; i < 28; i = i + 2)
			{
				Console.WriteLine();
				int[] temps = getEffectiveTemperatures(i);
				Console.Write("{0, 4}{1, 4}", windSpeedLabel[i / (int)increments] + " |", i + ":");

				// for each element in the corresponding effective temperature array,
				// print the values and color the cells if they match the condition
				foreach (int temp in temps) {
					if (temp <= -28)
					{
						Console.BackgroundColor = ConsoleColor.Gray;
						Console.ForegroundColor = ConsoleColor.Blue;
					}
					else
						Console.ResetColor();
                    // print temp with spacing of 5
					Console.Write("{0, 5}", temp);
				}
				Console.ResetColor();
			}

			Console.WriteLine();
			

		}

		private void printHeader(int lowerBound, int upperBound, int increments)
        {
			string temperatureLabel = "Temperature <°C>";
			int tableWidth = ((lowerBound - upperBound) / increments + 1) * 5 + 8; // width of table as number of characters

			Console.WriteLine("===========================================");
			Console.WriteLine("= The wind's influence on the temperature =");
			Console.WriteLine("= Presented in a nice lil' table          =");
			Console.WriteLine("===========================================");
			Console.WriteLine();
			Console.WriteLine("{0, 4}{1, 0}", "|", temperatureLabel.PadLeft(tableWidth / 2 + 3)); // center shift the label
			Console.Write("{0, 4}{1, 4}", "|", "");

			for (int i = lowerBound; i >= upperBound; i -= increments)
            {
                Console.Write("{0, 5}", i);
				if (i == upperBound)          // new line after last real temperature number
					Console.WriteLine();
            }
			Console.Write("".PadLeft(tableWidth, '-')); // header separator
		}

		/// <summary>
		/// Get an array of numbers corresponding to the effective temperatures depending on wind speed
		/// For each value in the temperature range array, change the value according to the given formula
		/// T(eff) = 13.12 + 0.6215 * T - 13.956 * v^(0.16) + 0.48669 * T * v^(0.16)
		/// Rounded to nearest integer
		/// </summary>
		/// <param name="windSpeed">Wind speed to base the calculation off</param>
		/// <returns>Array of effective temperatures</returns>
		private int[] getEffectiveTemperatures(int windSpeed)
        {
			int[] temperatureRange = {10, 8, 6, 4, 2, 0, -2, -4, -6, -8, -10, -12, -14, -16, -18, -20, -22, -24, -26, -28, -30};
			
			// change each value in the temperature range array according to the formula and round the results to integers
			for (int i = 0; i < temperatureRange.Length; i++)
            {
				double effectiveTemp = 13.12 + 0.6215 * temperatureRange[i] - 13.956 * Math.Pow(windSpeed, 0.16) + 0.48669 * temperatureRange[i] * Math.Pow(windSpeed, 0.16);
				temperatureRange[i] = (int) Math.Round(effectiveTemp);
            }
			return temperatureRange;
        }
	}
}
