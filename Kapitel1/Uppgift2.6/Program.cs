using System;

namespace Uppgift2._6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            // loop until user quits
            while(playAgain) {
                Guesser guesser = new Guesser();
                // continue playing until game over
                while(!guesser.GameOver)
                {
                    guesser.MakeGuess();
                }
                Console.WriteLine("Type N to quit or press a key to play again.");
                string input = Console.ReadLine();
                // get user input
                if (input == "N")
                    playAgain = false;
            }
        }
    }
}
