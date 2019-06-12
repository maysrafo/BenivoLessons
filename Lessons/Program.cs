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
            Console.Write("n = ");
            int n = UserInputNumber();
            Console.Write("c = ");
            char c = UserInputCharacter();
            Console.Clear();


            //Show the results
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n / 2; j++)
                {
                    
                    Console.Write(c);
                    

                }
                
                Console.WriteLine();
            }
           


        }

        //Function which will get userInput, validate it and return n
        public static int UserInputNumber()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please do not use Even numbers");
                Console.ResetColor();
                Console.Write("n = ");
                int b = Convert.ToInt32(Console.ReadLine());
                

                if (b % 2 == 1)
                {
                    Console.Clear();
                    t = b;
                    break;
                }

            }
            return t;
        }
                       

        //Function which will get userInput, validate it and return c
        public static char UserInputCharacter()
        {
            string input = Console.ReadLine();
            char c;

            while (input.Equals(null) || input.Equals(" ") || input.ToString().Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again");
                Console.ResetColor();
                Console.Write("c = ");

                string secondTry = Console.ReadLine();
                if (!input.Equals(null) || !input.Equals(" ") || input.ToString().Length <= 1)
                {
                    c = Convert.ToChar(secondTry);
                    break;
                }
               

            }

            c = Convert.ToChar(input);

            return c;
        }

    }
}
