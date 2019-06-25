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
            //Declare new array for Prices
            int[] prices = new int[5];

            //Ask the user to input an array
            Console.WriteLine("Please Enter you product prices");
            for (int i = 0; i < prices.Length; i++)
            {
                //Validating user input
                bool isValidInput = int.TryParse(Console.ReadLine(), out prices[i]);
                while (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter only number, Try again");

                    Console.ResetColor();
                    isValidInput = int.TryParse(Console.ReadLine(), out prices[i]);
                    
                }
                
            }

            Console.Clear();
            //Declare new array for Stores
            string[] stores = new string[5];

            //Ask the user to input an array for Stores
            Console.WriteLine("Please Enter you Store names");
            for (int i = 0; i < stores.Length; i++)
            {
                stores[i] = Console.ReadLine();
                
            }
            Console.Clear();

            int result1 = Math.Min(prices[0], prices[1]);
            int result2 = Math.Min(prices[2], prices[3]);
            int result3 = Math.Min(result2, prices[4]);
            int result = Math.Min(result1, result3);

            int target = 0;
            
            Console.WriteLine(result);






        }
    }   
}
