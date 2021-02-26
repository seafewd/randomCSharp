using System;
using System.Text;

namespace Uppgift2._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Cryptographer cryptographer = new Cryptographer();
            Console.WriteLine("Type something to encrypt:");
            string input = Console.ReadLine();
            string encrypted = cryptographer.EncryptOrDecrypt(input, true);
            Console.WriteLine("Your string encrypted: " + encrypted);

            Console.WriteLine("Press a key to decrypt.");
            Console.ReadKey();

            string decrypted = cryptographer.EncryptOrDecrypt(encrypted, false);
            Console.WriteLine("Your original string: " + decrypted);
        }
    }

    public class Cryptographer
    {

        public string EncryptOrDecrypt(string input, bool encryption)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
                sb.Append(EncryptSubString(c, encryption));
            return sb.ToString();
        }

        public string EncryptSubString(char c, bool encryption)
        {
            StringBuilder sb = new StringBuilder();
            int type;

            if (Char.IsLetter(c))
                type = 12;
            else if (Char.IsDigit(c))
                type = 5;
            else
                type = 12;

            for(int i = 0; i < type; i++)
            {
                char subString;
                if(encryption)
                    subString = (char)(c + 1);
                else
                    subString = (char)(c - 1);
                sb.Append(subString);
            }
            return sb.ToString();
        }
    }
}
