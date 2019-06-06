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
            //Introduction
            Console.WriteLine("Please answer some question to have you onboard, please Enter to continue");
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
                Console.WriteLine("Sorry, you are not allowed to Sign up");
            }
            else
            {

                Console.WriteLine("You are allowed to continue\n");

                //Email Address input
                Console.WriteLine("Please enter your email :");
                string emailInput = EmailAddress();

                //Validation email Address
                Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchEmail = regexEmail.Match(emailInput);
                if (matchEmail.Success)
                {
                    Console.WriteLine(emailInput + "format is correct");
                    Console.Clear();
                
                }
                else
                {
                    Console.WriteLine(emailInput + "is incorrect, try again");
                    Console.Clear();
                    //EmailAddress();
                    //Console.WriteLine(emailInput + "is again incorrect, try again the last time :(");
                    //EmailAddress();
                    //Console.WriteLine("Sorry you are not allowed to Sign up");
                }


                //password
                Console.WriteLine("Please enter your password. Please note It must contain at least a number, one upper case letter and 8 characters long");
                string userPassword = UserPassword();

                //Password Validation
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");

                bool isValidated = hasNumber.IsMatch(userPassword) && hasUpperChar.IsMatch(userPassword) && hasMinimum8Chars.IsMatch(userPassword);

                if (isValidated)
                {
                    Console.WriteLine("Your password format is correct");
                }
                else
                {
                    Console.WriteLine("Please Enter a valid password");
                    //UserPassword();
                    //Console.WriteLine("Please Enter a valid password last time");
                    //UserPassword();
                    //Console.WriteLine("Oooops, you are not allowed to Enter password, Try again Later");
                    //Console.Clear();
                }

                //firstname
                Console.WriteLine("Please Enter your FirstName");
                string firstName = UserFirstName();

                //firstname validation
                if (!Regex.Match(firstName, "^[A-Z][a-zA-Z]*$").Success)
                {
                    Console.WriteLine("Please do not use numbers in your name");
                    //UserFirstName();
                    //Console.WriteLine("Please do not use numbers in your name, this is last opprtunity");
                    //UserFirstName();
                    //Console.WriteLine("You are not allowed to continue");
                    //Console.Clear();

                }
                else
                {
                    Console.WriteLine("Your First Name format is correct");
                }

                //lastname
                Console.WriteLine("Please Enter your LastName");
                string lastname = UserLastName();

                //lastname validation
                if (!Regex.Match(lastname, "^[A-Z][a-zA-Z]*$").Success)
                {
                    Console.WriteLine("Please do not use numbers in your name");
                    //UserLastName();
                    //Console.WriteLine("Please do not use numbers in your name, try again");
                    //UserLastName();
                    //Console.WriteLine("You are not allowed to continue");
                    //Console.Clear();

                }
                else
                {
                    Console.WriteLine("Your First Name format is correct");
                }


                //day of birthday
                Console.WriteLine("Please Enter your Day of birthday");
                string day = Console.ReadLine();

                int birthday_day;

                birthday_day = int.Parse(day);


                //month of birthday
                Console.WriteLine("Please Enter Month of your birthday");
                string month = Console.ReadLine();

                int birthday_month;

                birthday_month = int.Parse(month);



                //Year of birthday
                Console.WriteLine("Please Enter Year of your birthday");
                string year = Console.ReadLine();

                int birthday_year;

                birthday_year = int.Parse(year);


                //Converting user inputs to date

                string bornDate = $"{year}-{month}-{day}";

                DateTime dt;
                //dt = DateTime.ParseExact(bornDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                dt = new DateTime(birthday_year, birthday_month, birthday_day);



                //Return Output
                string output;
                Console.WriteLine($"Hi {firstName} {lastname}, you are registered with account {emailInput}. Your have born on {dt}");

                DateTime today = DateTime.Now;


                TimeSpan dayCount = (DateTime.Now - dt);
                int totalYear = (int)dayCount.TotalDays / 365;

                if (totalYear == age)
                {
                    Console.WriteLine("You are registered successfully");

                }
                else
                {
                    Console.WriteLine("You are sharper");

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
