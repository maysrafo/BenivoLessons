using System;
using System.Globalization;
using Lessons.Payouts;
using System.Regex;
using System.Linq;

namespace Lessons
{
    class Program
    {
        public static void Main()
        {
            //Declare new array for Prices

            int[] prices = new int[5];

            //Ask the user to input an array
            Console.WriteLine("Please Enter you product prices");
            for (int k = 0; k < prices.Length; k++)
            {

                //Validating user input
                bool isValidInput = int.TryParse(Console.ReadLine(), out prices[k]);

                while (!isValidInput)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter only number, Try again");

                    Console.ResetColor();
                    isValidInput = int.TryParse(Console.ReadLine(), out prices[k]);
                }

            }


            Console.Clear();
            //Declare new array for Stores
            string[] stores = new string[5];

            //Ask the user to input an array for Stores
            Console.WriteLine("Please Enter you Store names");
            for (int j = 0; j < stores.Length; j++)

                stores[j] = Console.ReadLine();


            Console.Clear();


            //Show the user Store names and prices
            Console.WriteLine("---------------------------------");
            Console.WriteLine("See the stores and prices below");
            Console.WriteLine("---------------------------------");
            for (int l = 0; l < stores.Length; l++)
            {

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{stores[l]}    {prices[l]}");
            }

            Console.ResetColor();



            //Find the minimum price along prices using System Linq
            int result = prices.Min();
            

            //Show corresponding Store Name
            int i, index = 0;
            for (i = 1; i < prices.Length; i++)

                if (prices[i] == result)

                    index = i;




            Console.WriteLine("---------------------------------");
            Console.WriteLine($"The minimum price for the product you're searching for is in the {stores[index]} store and the price is {prices[index]} if you want to buy this product please enter your Payment Method");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please note that we support two payment methods:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("PayPal & Credit Card");
            Console.ResetColor();

            Console.WriteLine("---------------------------------");

            int price = prices[index];

            //Ask for PaymentMethod
            string method = Console.ReadLine();

            switch (method)
            {

                case "PayPal":

                    //PayPal Email input and validation
                    Console.WriteLine("Please Enter your email");
                    string emailInput = Console.ReadLine();

                    Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match matchEmail = regexEmail.Match(emailInput);
                    while (!matchEmail.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter valid email address");
                        Console.ResetColor();

                        emailInput = Console.ReadLine();
                        regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        matchEmail = regexEmail.Match(emailInput);
                    }


                    //PayPal password input and validation
                    Console.WriteLine("Please Enter your password");
                    string userPassword = Console.ReadLine();

                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars = new Regex(@".{8,}");

                    bool isValidated = hasNumber.IsMatch(userPassword) && hasUpperChar.IsMatch(userPassword) && hasMinimum8Chars.IsMatch(userPassword);
                    while (!isValidated)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please Enter a valid password");
                        Console.ResetColor();
                        userPassword = Console.ReadLine();
                        isValidated = hasNumber.IsMatch(userPassword) && hasUpperChar.IsMatch(userPassword) && hasMinimum8Chars.IsMatch(userPassword);
                    }

                    Pay(emailInput, ref price);
                    Console.WriteLine($"You are going to process {price}\n-------------------------");
                    Console.WriteLine("Please Enter to Process");
                    Console.WriteLine("-------------------------");
                    Console.ReadLine();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Consgratulations. You have successfully made a payment");


                    break;
                case "Credit Card":
                    Console.WriteLine("Please Enter your Credit Card number");
                    string creditCardNumber = Console.ReadLine();
                    while (creditCardNumber.Length != 16)
                    {
                        Console.WriteLine("Please enter a 16 length number");
                        creditCardNumber = Console.ReadLine();
                    }

                    Console.WriteLine("Please enter your cvv code");
                    int cvvCode;
                    string cvvInput = Console.ReadLine();
                    bool isValidCvv = int.TryParse(cvvInput, out cvvCode);
                    while (isValidCvv || cvvInput.Length != 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Try again");
                        Console.ResetColor();

                        cvvInput = Console.ReadLine();
                        isValidCvv = int.TryParse(cvvInput, out cvvCode);
                    }
                    Pay(creditCardNumber, cvvCode, ref price);

                    Console.WriteLine($"You are going to process {price}\n-------------------------");
                    Console.WriteLine("Please Enter to Process");
                    Console.WriteLine("-------------------------");
                    Console.ReadLine();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Consgratulations. You have successfully made a payment");

                    break;

                default :

                   Console.WriteLine("Please Enter correct Method Name");
                    
                    break;
            }


        }

        public static void Pay(string paypal, ref int amount)
        {
            amount = amount - (amount * 3 / 100);
        }

        public static void Pay(string cardNumber, int cvv, ref int amount)
        {
            amount = amount + 2;
        }


    }   
}
