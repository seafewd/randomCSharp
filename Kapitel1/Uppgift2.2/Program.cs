using System;
using System.Text;

namespace Uppgift2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticVariable sv1 = new StaticVariable();
            StaticVariable sv2 = new StaticVariable();
            StaticVariable sv3 = new StaticVariable();
            StaticVariable sv4 = new StaticVariable();
            StaticVariable sv5 = new StaticVariable();
            StaticVariable sv6 = new StaticVariable();

            Console.WriteLine(StaticVariable.GetCounter());
        }
    }

    public class StaticVariable
    {
        private static int counter = 0;
        private readonly Guid id;

        public StaticVariable()
        {
            // inc static counter
            counter++;

            // generate id
            //id = GenerateId(50);
            // or be boring:
            id = Guid.NewGuid();
            Console.WriteLine("Created a StaticVariable object.\nNumber of objects: " + counter + "\nID: " + GetId() + "\n----------");
        }

        /// <summary>
        /// Get counter var
        /// </summary>
        /// <returns></returns>
        public static int GetCounter()
        {
            return counter;
        }

        /// <summary>
        /// Generate ID of numbers with length n
        /// </summary>
        /// <param name="length">length of ID</param>
        /// <returns></returns>
        private string GenerateId(int length)
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append(rand.Next(0, 10));
            return sb.ToString();
        }

        /// <summary>
        /// Get ID
        /// </summary>
        /// <returns></returns>
        public Guid GetId()
        {
            return id;
        }
    }
}
