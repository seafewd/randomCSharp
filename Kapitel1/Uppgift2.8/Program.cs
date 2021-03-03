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
            // letter, number, special char etc
            int index = 0;
            char subString = ' ';
            char character = input[index];

            if (Char.IsLetter(character)) {
                for (int i = 0; i < 12; i++)
                {
                    subString = (char)(character + 1);
                    if (!encryption)
                        i += 7;
                }
            }
            else if (Char.IsDigit(character))
            {
                for (int i = 0; i < 5; i++)
                {
                    subString = (char)(character + 1);
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    subString = (char)(character + 1);
                }
            }
            sb.Append(subString);
            return sb.ToString();
        }
    }
}
