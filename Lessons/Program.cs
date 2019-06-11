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
            //Intializing new user input and converting to float
            Console.WriteLine("Welcome to online payment system, Please input your amount below");

            //User input validation
            string userInput = AskForInput();
            float amount;
            if (float.TryParse(userInput, out amount))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Please select a payment method:\nVisa       MasterCard       PayPal");
                Console.ResetColor();
                string paymentMethod = Console.ReadLine();
                Console.Clear();

                //Handle Payment Methods
                switch (paymentMethod)
                {
                    case "Visa":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Please input your cvv code");
                        Console.ResetColor();

                        //Ask for cvv code
                        string cvvCode = Console.ReadLine();
                        int code;
                        if (int.TryParse(cvvCode, out code) && cvvCode.Length == 3)
                        {
                            Console.WriteLine($"You are trying to process {amount}, Enter to confirm");
                            Console.ReadLine();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Your payment is processed successfully");
                        }
                        else
                        {
                            Console.WriteLine("cvv code should contain only 3 numbers");
                        }                    

                        break;

                    case "MasterCard":

                        //Discount the amount by 5 %
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Please note that your amount({amount}) will be discounted by 5 %\nEnter to continue");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();

                        amount = amount - (amount * 5 / 100);
                        Console.WriteLine($"Your amount is discounted to {amount}, Enter to confirm");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your payment is processed successfully");    
                        
                        break;

                        //Add 2% service fee
                    case "PayPal":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Please note that PayPal will use 2% service fee,Enter to continue");
                        Console.ReadKey();
                        Console.Clear();

                        float fee = (amount * 2 / 100);
                        float result = fee + amount;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Your amount is {amount} , and PayPal service fee is {fee}\n{amount} + {fee} = {result}");
                                            
                        break;
                    default:
                        Console.WriteLine("Please input correct method name");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Please use only numbers");


            }
  

        }
        //Function to Ask the user to input amount
        public static string AskForInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        
    }
}
