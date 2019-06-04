using System;
using System.Globalization;
using Lessons.Payouts;

namespace Lessons
{
    class Program
    {
        static void Main()
        {
            //Introduction
            Console.WriteLine("Welcome to Benivo, to continue please Enter");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please answer some question to have you onboard");

            //Check User age
            Console.WriteLine("How old are you?");
            string userAge = Console.ReadLine();

            int age;
            age = int.Parse(userAge);

            if (age > 18 || age == 18)
            {
                Console.WriteLine("You are allowed to continue your sign up process");

                //email
                Console.WriteLine("Please enter your email :");
                
                string userEmail = Console.ReadLine();
            

                //password
                Console.WriteLine("Please enter your password");
                
                string userPassword = Console.ReadLine();

                //firstname
                Console.WriteLine("Please Enter your FirstName");
                string firstName = Console.ReadLine();

                //lastname
                Console.WriteLine("Please Enter your LastName");
                string lastname = Console.ReadLine();

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
                Console.WriteLine($"Hi {firstName} {lastname}, you are registered with account {userEmail}. Your have born on {dt}");

                DateTime today = DateTime.Now;

                //if (dt.Date.Year > today.AddYears(-age).Year && dt.Date.Month > today.AddYears(-age).Month && dt.Date.Day > today.AddYears(-age).Day)
                ////{
                //    Console.WriteLine("You did not lie :)");
                //}
                //else
                //{
                //    Console.WriteLine("You are sharper");
                //}



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
            }
            else
            {
                Console.WriteLine("Sorry, you are not allowed to Sign up");
          
            }

            Console.ReadKey();


        }
    }
}
