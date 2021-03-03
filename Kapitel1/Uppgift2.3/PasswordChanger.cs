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
                Console.WriteLine();
                if (input != pwc.password)
                    Console.WriteLine("Wrong password. Try again.\n");
                else
                    break;
                    
            }
            // if input matches the user's password we continue
            if(input == pwc.password)
            {
                while (true)
                {
                    Console.WriteLine("Enter new password: ");
                    string newPw = Console.ReadLine();
                    // check the new password against the criteria, repeat process if insufficient quality
                    if (pwc.checkPassword(newPw))
                    {
                        // repeat the new password to confirm change
                        Console.WriteLine("Repeat password: ");
                        string repeatPw = Console.ReadLine();
                        // passwords don't match - reloop
                        if (repeatPw != newPw)
                            Console.WriteLine("Passwords don't match. Try again.");
                        else
                            break;
                    }
                    else
                        Console.WriteLine("Password needs to be at least 8 characters long,\n" +
                            "contain a number and include a special character.\nTry again.\n");
                }
                Console.WriteLine("Your password has been changed. Enjoy.");
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
            // check if the password contains some symbol other than aA-zZ-0-9
            bool containsSpecialChar = !rgx.IsMatch(pw);
            bool containsUppercase = pw.Any(char.IsUpper);
            bool containsLowercase = pw.Any(char.IsLower);
            return lengthOk && containsNumber && containsSpecialChar && containsUppercase && containsLowercase;

        }
    }
}
