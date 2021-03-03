using System;
using System.Collections.Generic;

namespace Uppgift1._10
{
    class Program
    {

        static void Main(string[] args)
        {
            Program main = new Program();
            string numerals = "XXXIII";
            string numerals2 = "DDXV";
            string numerals3 = "MMXXI";
            string numerals4 = "VVVVI";

            // for easy testing
            string argument = numerals3;

            Console.WriteLine("Roman numerals \"" + argument + "\" in arabic numerals:");
            Console.WriteLine(main.ParseRomanNumerals(argument));

        }

        /// <summary>
        /// Create a dictionary and fill it with roman numerals and their corresponding arabic numerals
        /// Loop through each character in passed string and if match, add corresponding value
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        private int ParseRomanNumerals(string chars)
        {
            // create & fill dictionary
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('M', 1000);
            dict.Add('D', 500);
            dict.Add('C', 100);
            dict.Add('L', 50);
            dict.Add('X', 10);
            dict.Add('V', 5);
            dict.Add('I', 1);
            dict.Add('m', 1000);
            dict.Add('d', 500);
            dict.Add('c', 100);
            dict.Add('l', 50);
            dict.Add('x', 10);
            dict.Add('v', 5);
            dict.Add('i', 1);

            int resultInArabic = 0;


            // loop through each key in dictionary
            foreach (char c in chars.ToCharArray())
            {
                // add corresponding value if character is found
                if (dict.ContainsKey(c))
                    resultInArabic += dict[c];
                    
            }

            return resultInArabic;
        }
    }
}
