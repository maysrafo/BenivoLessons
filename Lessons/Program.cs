using System;
using System.Globalization;
using Lessons.Payouts;
using System.Regex;

namespace Lessons
{
    class Program
    {
        static void Main()
        {
            ConsoleColor foreground = Console.ForegroundColor;


            //Introduction
            Console.WriteLine("Please answer some questions to have you onboard, please Enter to continue");
            Console.ReadLine();
            Console.Clear();

            //Asking user age
            Console.WriteLine("How old are you?");
            string userAge = Console.ReadLine();
            Console.Clear();

            int age;
            age = int.Parse(userAge);

            //Validating user age
            if (age < 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, you are not allowed to Sign up");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You are allowed to continue\n");

                //Email Address input
                Console.ResetColor();
                Console.WriteLine("Please enter your email :");
                string firstEmailInput = EmailAddress();
                Console.Clear();

                //Validation email Address
                Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchEmail = regexEmail.Match(firstEmailInput);
                if (matchEmail.Success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your email format is correct");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Your Email format is incorrect, try again");

                    Console.ResetColor();
                    string secondEmailInput = EmailAddress();
                    Console.Clear();
                    Match matchEmail1 = regexEmail.Match(secondEmailInput);

                    if (matchEmail1.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your Email format is correct\n");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your email format is incorrect\n");

                    }

                }




                //password
                Console.ResetColor();
                Console.WriteLine("Please enter your password. Please note It must contain at least a number, one upper case letter and 8 characters long");
                string userPassword = UserPassword();
                Console.Clear();

                //Password Validation
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");

                bool isValidated = hasNumber.IsMatch(userPassword) && hasUpperChar.IsMatch(userPassword) && hasMinimum8Chars.IsMatch(userPassword);

                if (isValidated)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your password format is correct, please Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a valid password");
                    Console.ResetColor();
                    string passResult = UserPassword();
                    Console.Clear();
                    var hasNumber1 = new Regex(@"[0-9]+");
                    var hasUpperChar1 = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars1 = new Regex(@".{8,}");

                    bool isValidated1 = hasNumber1.IsMatch(passResult) && hasUpperChar1.IsMatch(passResult) && hasMinimum8Chars1.IsMatch(passResult);

                    if (isValidated1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your password format is correct now\n ");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your password is again incorrect, you are not allowed to continue, please Enter");
                        Console.ReadLine();
                        Console.Clear();
                    }




                }

                //firstname
                Console.ResetColor();
                Console.WriteLine("Please Enter your FirstName");
                string firstName = UserFirstName();

                //firstname validation
                if (Regex.Match(firstName, "^[A-Z][a-zA-Z]*$").Success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please do not use numbers in your name next time :)");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your First Name format is correct, Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }

                //lastname 
                Console.ResetColor();
                Console.WriteLine("Please Enter your LastName");
                string lastname = UserLastName();

                //lastname validation
                if (Regex.Match(lastname, "^[A-Z][a-zA-Z]*$").Success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please do not use numbers in your name next time :)");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your Last Name format is correct, Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }


                //day of birthday
                Console.ResetColor();
                Console.WriteLine("Please Enter your Day of birthday");
                string day = Console.ReadLine();
                Console.Clear();

                int birthday_day;

                birthday_day = int.Parse(day);


                //month of birthday
                Console.WriteLine("Please Enter Month of your birthday");
                string month = Console.ReadLine();
                Console.Clear();

                int birthday_month;

                birthday_month = int.Parse(month);



                //Year of birthday
                Console.WriteLine("Please Enter Year of your birthday");
                string year = Console.ReadLine();
                Console.Clear();

                int birthday_year;

                birthday_year = int.Parse(year);


                //Converting user inputs to date

                string bornDate = $"{year}-{month}-{day}";

                DateTime dt;
                //dt = DateTime.ParseExact(bornDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                dt = new DateTime(birthday_year, birthday_month, birthday_day);



                //Return Output
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Hi {firstName} {lastname}, you are registered with account {firstEmailInput}. Your born date  is {dt}");

                DateTime today = DateTime.Now;


                TimeSpan dayCount = (DateTime.Now - dt);
                int totalYear = (int)dayCount.TotalDays / 365;

                if (totalYear == age)
                {
                    Console.WriteLine("You are registered successfully");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\nBut a quick note to you, You are sharper you have deceived us that you are {age} years old");

                }

                Console.ReadKey();

            }


        }

        //Function to ask user to input Email Address
        public static string EmailAddress()
        {
            string userEmail = Console.ReadLine();
            return userEmail;

        }

        //Function to ask user to input Password
        public static string UserPassword()
        {
            string password = Console.ReadLine();
            return password;
        }

        //Function to ask user to input First name
        public static string UserFirstName()
        {
            string inputFirstName = Console.ReadLine();
            return inputFirstName;
        }

        //Function to ask user to input Last name
        public static string UserLastName()
        {
            string inputLastName = Console.ReadLine();
            return inputLastName;
        }
    }
}
