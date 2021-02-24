using System;

namespace Uppgift1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SomeFunc(-10));
            Console.WriteLine(CalcIntegral(-10, 11, 100000));
        }

        /*
         * Returns the integral of a given function
         * 
         * Algorithm:
         * - Let dx be the set of x values to be integrated. (divide the interval/segment by n to get the size of each element of x. larger n means smaller x vales)
         * - Calculate the integral by summing up all the f(x0..xn) * x0  (each multiplication will result in a rectangle with base x0 and height f(xi))
         * - return the sum
         */
        public static double CalcIntegral(double a, double b, int n)
        {
            double dx = Math.Abs(b - a) / n;

            double sum = 0;

            for (int i = 0; i < n; i++)
                sum += dx * SomeFunc(a + i * dx); // replace with any function

            return sum;

        }

        public static double YeqX(double x)
        {
            return x; // y = x
        }

        public static double XSquared(double x)
        {
            return x * x;
        }

        public static double SomeFunc(double x)
        {
            return x * x * x + 2 * x - 14;
        }
    }
}
