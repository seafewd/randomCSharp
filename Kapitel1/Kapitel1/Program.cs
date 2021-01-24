using System;

namespace Kapitel1
{
	class Program
	{
		static void Main(string[] args)
		{
			Program main = new Program();                       // create main object

			while (true)                                        // allow multiple runs by endlessly looping the program until user types "exit"
			{
				int speed = main.getSpeed();					// get user speed
				int distance = main.getRemainingDistance();		// get user distance remaining
				main.calculateTime(speed, distance);			// calculate time remaining

				Console.WriteLine("Type \"exit\" to quit. Press Enter to try again.");
				string input = Console.ReadLine();
				if (input.ToLower() == "exit")					// break loop if user types exit
					break;
			}
		}

		/// <summary>
		/// Get user's average speed
		/// </summary>
		/// <returns>int of average speed in km</returns>
		private int getSpeed()
		{
			Console.Write("Enter average speed (km/h): ");		// ask for user input
			string input = Console.ReadLine();					// save input
			int speed;											// declare variable for speed

			bool isNumber = Int32.TryParse(input, out speed);	// try to parse the user's input. only allow int values

			if (!isNumber)										// check if user's input is clean/is a number
			{
				Console.WriteLine("Please use only integers to input your speed.\n");	 // inform user of faulty input
				getSpeed();																// re-run this method in order to ask user again
			}
			return speed;										// return user's average speed
		}

		/// <summary>
		/// Get user's remaining distance
		/// </summary>
		/// <returns>int of remaining distance in km</returns>
		private int getRemainingDistance()
		{
			Console.Write("Enter remaining distance (km): ");
			string input = Console.ReadLine();
			int distance;

			bool isNumber = Int32.TryParse(input, out distance);

			if (!isNumber)
			{
				Console.WriteLine("Please use only integers to input your speed.\n");
				getRemainingDistance();
			}
			return distance;
		}

		/// <summary>
		/// Calculate the remaining time in hours, minutes
		/// </summary>
		/// <param name="speed">User's average speed</param>
		/// <param name="distance">User's distance remaining</param>
		private void calculateTime(int speed, int distance)
		{
			if (speed == 0)			// if speed is 0 we won't get anywhere. also we don't want to divide by zero...
			{
				Console.WriteLine("Unfortunately, with a speed of 0 km/h you will never be able to finish your trip. Try again...\n");
				return;
			}
			float totalMinutesLeft = (float) distance / (float) speed * 60;		// calc total minutes remaining
			int hours = (int) totalMinutesLeft / 60;							// calc whole hours left
			int minutes = (int) totalMinutesLeft % 60;							// calc whole minutes left


			if (minutes == 0)
				Console.WriteLine("The remaining time of your trip is approximately {0} hour(s).\n", hours);
			else if (hours == 0)
				Console.WriteLine("The remaining time of your trip is approximately {0} minute(s).\n", minutes);
			else
				Console.WriteLine("The remaining time of your trip is approximately {0} hour(s) and {1} minutes.\n", hours, minutes);
		}
	}
}
