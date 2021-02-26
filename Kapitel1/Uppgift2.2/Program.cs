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
        }
    }

    public class StaticVariable
    {
        private static int counter = 0;
        private readonly string id;

        public StaticVariable()
        {
            counter++;
            id = GenerateId(10);
            Console.WriteLine("Created a StaticVariable object.\nNumber of objects: " + counter + "\nID: " + GetId() + "\n----------");
        }

        public static int GetCounter()
        {
            return counter;
        }

        private string GenerateId(int length)
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append(rand.Next(0, 10));
            return sb.ToString();
        }

        public string GetId()
        {
            return id;
        }
    }
}
