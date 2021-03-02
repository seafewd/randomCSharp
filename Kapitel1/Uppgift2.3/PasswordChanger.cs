using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Uppgift2._3
{
    class PasswordChanger
    {
        private string password;

        public PasswordChanger(string pw)
        {
            this.password = pw;
        }
        static void Main(string[] args)
        {
            PasswordChanger pwc = new PasswordChanger("F60gT%ft2$U");
            string input;
            Console.WriteLine("Welcome to password changer.\n");
            while (true)
            {
                Console.WriteLine("Enter your old password: ");
                input = Console.ReadLine();
                if (input != pwc.password)
                    Console.WriteLine("Wrong password. Try again.");
                else
                    break;
                    
            }
            if(input == pwc.password)
            {
                Console.WriteLine("Enter new password: ");
                while (true)
                {
                    string newPw = Console.ReadLine();
                    if (pwc.checkPassword(newPw))
                    {
                        Console.WriteLine("Your password has been changed. Enjoy.");
                        break;
                    }
                    else
                        Console.WriteLine("Password needs to be at least 8 characters long,\n" +
                            "contain a number, a special character.\nTry again.");
                }
            }
        }

        /// <summary>
        /// Check if the new password meets the criteria
        /// Using regex to check for special characters
        /// </summary>
        /// <param name="pw">Password to check</param>
        /// <returns>True if password OK</returns>
        private bool checkPassword(string pw)
        {
            Regex rgx = new Regex(@"^[a-zA-Z0-9_@.-]*$");
            bool lengthOk = pw.Length >= 8;
            bool containsNumber = pw.Any(char.IsDigit);
            bool containsSpecialChar = !rgx.IsMatch(pw);
            Console.WriteLine(containsSpecialChar);
            bool containsUppercase = pw.Any(char.IsUpper);
            bool containsLowercase = pw.Any(char.IsLower);
            return lengthOk && containsNumber && containsSpecialChar && containsUppercase && containsLowercase;

        }
    }
}
