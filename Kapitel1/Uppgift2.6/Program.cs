using System;

namespace Uppgift2._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Guesser guesser = new Guesser();
            Console.WriteLine("guesese: " + guesser.GuessesLeft);
            Console.WriteLine("maxguesese: " + guesser.MaxGuesses);
            while(guesser.GuessesLeft >= 0 && !guesser.GameOver)
            {
                guesser.MakeGuess();
            }
        }
    }

    public class Guesser
    {
        Random rand = new Random();
        public const int maxGuesses = 7;
        private int guessesLeft;
        private int hiddenNumber;
        private bool gameOver;
        private int maxNumber = 100;

        public Guesser()
        {
            hiddenNumber = rand.Next((maxNumber + 1));
            guessesLeft = maxGuesses;
            gameOver = false;
            Console.WriteLine("Guess a number between 0 and " + maxNumber);
        }

        public bool MakeGuess()
        {
            if (guessesLeft <= 0)
            {
                Console.WriteLine("You failed. You don't have any more guesses.\nThe correct number was " + HiddenNumber + ".");
                gameOver = true;
                return false;
            }

            Console.Write("Guess #" + guessesLeft + ": ");
            bool inputOk = false;
            int guess = 0;
            while(!inputOk)
            {
                try
                {
                    guess = Int32.Parse(Console.ReadLine());
                    inputOk = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer number.");
                }
            }
            guessesLeft--;
            return CheckGuess(guess);
        }

        public bool CheckGuess(int input)
        {
            if(input == HiddenNumber)
            {
                Console.WriteLine("Congratulations. You win. whooooo.");
                gameOver = true;
                return true;
            }
            else if (input < HiddenNumber)
                Console.WriteLine(input + " is too low. You have " + guessesLeft + " left.");
            else if (input > HiddenNumber)
                Console.WriteLine(input + " is too high. You have " + guessesLeft + " left.");
            else
                Console.WriteLine("Unknown guessing error. Implosion imminent.");
            return false;
        }

        public int GuessesLeft
        {
            get { return guessesLeft; }
        }

        public int MaxGuesses
        {
            get { return maxGuesses; }
        }

        public int HiddenNumber
        {
            get { return hiddenNumber; }
        }

        public bool GameOver
        {
            get { return gameOver; }
        }
    }
}
