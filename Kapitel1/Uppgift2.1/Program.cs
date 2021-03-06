﻿using System;

namespace FractionDemo
{
    // Right now this the class Fractions in not immutable. An easy fix if necessary
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 2);
            Fraction f2 = new Fraction(4, 3);

            Console.WriteLine("Add fraction sloppy-test:");
            Console.WriteLine("Adding 3/2 and 4/3... should be 9/6 + 8/6 = 17/6 = 2 5/6");
            Console.WriteLine(f.ToString());
            Console.WriteLine(f2.ToString());

            f.AddFractions(f2);
            Console.WriteLine("multiplied: " + (f * f2).ToString());
            f.ToNormalForm();
            Console.WriteLine(f.ToString());
            f.ToMixedForm();
            Console.WriteLine(f.ToString());

            Console.WriteLine("gcd test:");
            Console.WriteLine(f.CalculateGCD(124, 35344) == 4);
        }
    }

    public class Fraction
    {
        private int wholeNumber;
        private int numerator;
        private int denominator;


        public Fraction(int wholeNumber, int numerator, int denominator)
        {
            this.wholeNumber = wholeNumber;
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction(int numerator, int denominator)
        {
            this.wholeNumber = 0;
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction()
        {
            this.wholeNumber = 0;
            this.numerator = 0;
            this.denominator = 1;
        }

        /*
         * Reduce the fraction
         * 
         * - Get the greatest common divisor
         * - Divide both values with the gcd
         */
        public void Reduce()
        {
            int gcd = CalculateGCD(Numerator, Denominator);

            Numerator = (Numerator / gcd);
            Denominator = (Denominator / gcd);
        }

        /*
         * Get the greatest common divisor using the euclidean algorithm.
         * 
         * gcd(a1,a2) = gcd(a2, a3), where a3 = the remainder of a1 / a2
         * gcd(a2, a3) = gcd(a3, a4), where a4 = the remainder of a2 / a3
         * etc...
         * 
         * Continue until the remainder is equal to zero.
         */
        public int CalculateGCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return CalculateGCD(b, a % b);
        }


        /*
         * Set the fraction to mixed form
         * 
         * Algorithm:
         * - Int-divide numerator by denominator to get the new whole number 
         * - Numerator mod denominator to get the new numerator 
         * - Denominator stays the same
         */

        public void ToMixedForm()
        {
            WholeNumber = (Numerator / Denominator);
            Numerator = (Numerator % Denominator);
        }

        /*
         * Set the fraction to normal form, eg. not mixed
         * 
         * Algorithm:
         * - Set the new numerator to the whole number times the denominator, and add that with the old numerator
         * - Set the whole number to zero
         */
        public void ToNormalForm()
        {
            Numerator = (WholeNumber * Denominator + Numerator);
            WholeNumber = 0;
        }


        /*
         * Add a given fraction to the fraction
         * 
         * Algorithm:
         * - Set both fractions to normal form (easier to add non-mixed fractions)
         * - Calculate the new denominator by multiplying the denominators of the fractions
         * - Calculate the new numerator by the multiplying the first fractions numerator with the second fractions denominator. Do the same for the other fraction
         * - Set the new values
         * - Reduce
         * - Set the fraction back to mixed form
         */
        public void AddFractions(Fraction other)
        {
            ToNormalForm();
            other.ToNormalForm();

            int newDenominator = this.Denominator * other.Denominator;

            this.Numerator = (Numerator * other.Denominator + this.Denominator * other.Numerator);
            this.Denominator = newDenominator;

            this.Reduce();
            this.ToMixedForm();
        }

        public static Fraction operator+(Fraction a, Fraction b)
        {
            Fraction fraction = new Fraction(a.WholeNumber, a.Numerator, a.Denominator);
            fraction.AddFractions(b);
            return fraction;
        }

        /*
         * Multiply with fraction
         * 
         * Algorithm:
         * - Set both fractions to normal form
         * - Set the new values by multiplying the numerators and denominators
         */
        public void MultiplyFraction(Fraction other)
        {
            this.ToNormalForm();
            other.ToNormalForm();

            this.Numerator = (this.Numerator * other.Numerator);
            this.Denominator = (this.Denominator * other.Denominator);

            this.ToMixedForm();
            other.ToMixedForm();
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction fraction = new Fraction(a.WholeNumber, a.Numerator, a.Denominator);
            fraction.MultiplyFraction(b);
            return fraction;
        }

        override
        public string ToString()
        {
            if (WholeNumber != 0)
                return WholeNumber + " " + Numerator + " / " + Denominator;
            else
                return Numerator + " / " + Denominator;
        }

        // Get / Set

        public int WholeNumber
        {
            get { return wholeNumber; }
            set { wholeNumber = value; }
        }

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set 
            {
                if (denominator == 0)
                    denominator = 1;
                else
                    denominator = value;
            }
        }

    }
}
