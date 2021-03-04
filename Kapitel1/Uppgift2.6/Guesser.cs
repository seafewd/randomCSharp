using System;

namespace Uppgift2._6 {

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
            // generate hidden number
            hiddenNumber = rand.Next((maxNumber + 1));
            guessesLeft = maxGuesses;
            gameOver = false;
            Console.WriteLine("Guess a number between 0 and " + maxNumber + ".\nYou have " + MaxGuesses + " guesses.");
        }

        /// <summary>
        /// Make a guess 
        /// </summary>
        /// <returns>Bool result of guess</returns>
        public bool MakeGuess()
        {
            if (guessesLeft <= 0)
            {
                Console.WriteLine("You failed. You don't have any more guesses.\nThe correct number was " + HiddenNumber + ".");
                gameOver = true;
                return false;
            }
            // output
            Console.Write("Guess #" + (MaxGuesses - guessesLeft + 1) + ": ");
            bool inputOk = false;
            int guess = 0;
            // run until input is acceptable
            while (!inputOk)
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
            // decrement guesses
            guessesLeft--;
            return CheckGuess(guess);
        }

        /// <summary>
        /// Check the guess that the user made
        /// </summary>
        /// <param name="input">User guess</param>
        /// <returns>Bool result of guess</returns>
        public bool CheckGuess(int input)
        {
            // win scenario
            if (input == HiddenNumber)
            {
                Console.WriteLine("Congratulations. You win. whooooo.");
                gameOver = true;
                return true;
            }
            // too low
            else if (input < HiddenNumber)
                Console.WriteLine(input + " is too low. You have " + guessesLeft + " guesses left.");
            // too high
            else if (input > HiddenNumber)
                Console.WriteLine(input + " is too high. You have " + guessesLeft + " guesses left.");
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