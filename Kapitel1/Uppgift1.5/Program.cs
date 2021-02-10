using System;

namespace Uppgift1._5
{
    class Program
    {
        private const int frames = 10;
        private int[] series = new int[frames]; 

        static void Main(string[] args)
        {
            Program Main = new Program();
            
        }

        private int CalculatePoints(int squareNumber, int throwNumber)
        {
            int points = 0;


            return points;
        }

        private void Bowl()
        {
            int pinsHit = 0;
            Console.WriteLine("How many pins did you hit?");
            try
            {
                pinsHit = Int32.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("Enter an integer number.");
            }

        }
    }
}
