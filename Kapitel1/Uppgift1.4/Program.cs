using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Uppgift1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program main = new Program();
            string fileName = @"matdata_uppgift14.txt";
            List<string> data = main.getData(fileName);
            Console.WriteLine("Loaded file.");
            int intensity = main.getDesiredIntensity();
            List<string> prunedData = main.pruneList(data, intensity);

            Console.WriteLine("List of peaks: ");
            foreach (string s in prunedData)
                Console.WriteLine(s);

        }

        private List<string> getData(string path)
        {
            List<string> data = new List<string>();

            try
            {
                data = File.ReadAllLines(path).ToList();
                foreach (string line in data) { }

            }
            catch (Exception e)
            {
                Console.WriteLine("File not found.\nStack trace:");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(e);
                Console.WriteLine("---------------------------------------------");
            }
            return data;
        }

        private int getDesiredIntensity()
        {
            int intensity = 0;
            while (true) {
                Console.Write("Enter desired intensity: ");
                
                try
                {
                    string input = Console.ReadLine();
                    intensity = Int32.Parse(input);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter an integer number.\n");
                }
            }
            return intensity;
        }

        private List<string> pruneList(List<string> data, int intensity)
        {
            List<string> prunedData = new List<string>();
            int lineCount = 0;
            // foreach line in data
            // if intensity >= line.intensity
            // add line to prunedData

            foreach (string line in data) {
                if (lineCount == 0) // skip first row which only includes header labels
                {
                    lineCount++;
                    continue;
                }

                string sign = line.Substring(line.IndexOf('e') + 1, 1); // get exponent sign (pos. or neg.)

                try
                {
                    Console.WriteLine(line.Substring(line.IndexOf('e') + 2));
                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";

                    double coeff = Convert.ToDouble(line.Substring(0, line.IndexOf('e')), provider);

                    double exponent = Convert.ToDouble(line.Substring(line.IndexOf('e') + 2));
                    double value;

                    Console.WriteLine("coeff: " + coeff + ", exponent: " + exponent);

                    if (sign == "+")
                        value = coeff * Math.Pow(10, Convert.ToDouble(exponent));
                    else if (sign == "-")
                        value = coeff * Math.Pow(10, -Convert.ToDouble(exponent));
                    else
                        Console.WriteLine("Sign error!\nMust be either \"+\" or \"-\"");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Could not convert coefficient or exponent.");
                    throw;
                }

            }

            return prunedData;
        }
    }
}
