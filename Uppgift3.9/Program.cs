using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MorseCodeTranslator
{
    /// <summary>
    /// Morse code translator
    /// TODO: Writes file to disk
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Program main = new Program();

            // morse code for ABCD
            string tempCode = ".- -... -.-. -.. .";

            // separates original string into array of strings
            string[] test = main.SplitMorse(tempCode);

            // sloppy-test translation
            Dictionary<string, string> morseDict = main.ReadTextFile();

            Console.WriteLine(main.TranslateMorse(tempCode, morseDict));

        }



        // Splits the string into an array of strings, separated by space
        private string[] SplitMorse(string code)
        {
            string[] morseChars = code.Split(' ');

            return morseChars;
        }


        // Returns a dictionary of key value pairs of morse code
        // *Reads the morse tranlation dictionary text file (formatted with 2 columns) 
        public Dictionary<string, string> ReadTextFile()
        {
            string line;
            string path = @"C:\Users\robin\Documents\morse-code.txt";
            string path2 = @"C:\Users\Alexander\Sync\Documents\DV@GU\c#_1\labs\labs\randomCSharp\Uppgift3.9/morse-code.txt";

            Dictionary<string, string> morseTranslationDictionary = new Dictionary<string, string>();

            // Read the file and display it line by line.
            using (StreamReader file = new StreamReader(path2))
            {
                while ((line = file.ReadLine()) != null)
                {

                    char[] delimiters = new char[] { '\t' };
                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i = i + 2) // 2 steps on each iteration
                    {
                        morseTranslationDictionary.Add(parts[i + 1], parts[i]);
                    }
                }

                file.Close();
            }

            return morseTranslationDictionary;
        }


        public string TranslateMorse(string code, Dictionary<string, string> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            string[] morseWords = SplitMorse(code);

            // foreach morse word:
            // take the correct value from the dictionary and put it into a new string

            foreach (string word in morseWords)
            {
                sb.Append(dictionary[word]);
            }

            return sb.ToString();
        }
    }

    public class Translator
    {

    }
}
