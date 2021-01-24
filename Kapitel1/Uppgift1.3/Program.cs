﻿using System;

namespace Uppgift1._3
{
	class Program
	{
		static void Main(string[] args)
		{
			Program main = new Program();

			Console.WriteLine("================================================");
			Console.WriteLine("= The influence of the wind on the temperature =");
			Console.WriteLine("= Presented in a nice lil' table               =");
			Console.WriteLine("================================================");
			main.printTemperatureTable();
		}

		private void printTemperatureTable()
		{
			printHeader();
			
			for (int i = 2; i < 28; i = i + 2)
            {
				Console.WriteLine();
				int[] temps = getEffectiveTemperatures(i);

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
			}
			Console.WriteLine();
			Console.ResetColor();
		}

		private void printHeader()
        {
			Console.WriteLine("Temperature <°C>");
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
