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
            //Ask for Money
            Console.WriteLine("How much money do you have?\n---------------------------------");
            int money;
            bool isValid = int.TryParse(Console.ReadLine(), out money);
            while (!isValid)
            {
                Console.WriteLine("Please input a number");
                isValid = int.TryParse(Console.ReadLine(), out money);
            }

            //Ask for array Length same Product quantity
            Console.WriteLine("Please Enter your products quantity : ");
            Console.WriteLine("---------------------------------");

            int arrayLength = Convert.ToInt32(Console.ReadLine());

            //Declare new array for Prices
            int[] prices = new int[arrayLength];

            //Ask the user to input an array, product prices
            Console.WriteLine("Please Enter you product prices");
            Console.WriteLine("---------------------------------");
            for (int k = 0; k < prices.Length; k++)
            {

                bool isValidInput = int.TryParse(Console.ReadLine(), out prices[k]);

                //Validating user input
                while (!isValidInput)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter only number, Try again");

                    Console.ResetColor();
                    isValidInput = int.TryParse(Console.ReadLine(), out prices[k]);
                }

            }

            //Declare new array for Stores
            string[] stores = new string[arrayLength];

            //Ask the user to input an array for Stores
            Console.WriteLine("Please Enter Store names");
            Console.WriteLine("---------------------------------");
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

            int price = prices[index];

            //Print text
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"The minimum price for the product you're searching for is in the {stores[index]} store and the price is {prices[index]} if you want to buy this product please enter your Payment Method");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please note that we support two payment methods:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("PayPal & Credit Card");
            Console.ResetColor();

            Console.WriteLine("---------------------------------");



            //Ask for PaymentMethod
            string method = PaymentMethod();

            //Match Payment method and do corresponding actions
            switch (method)

            {

                case "PayPal":

                    //PayPal Email input
                    Console.WriteLine("Please Enter your email");
                    string emailInput = Console.ReadLine();

                    //Call Pay function to Validate PayPal, ask and validate Password and do some discount
                    Pay(emailInput, price, out int finalPrice);

                    //Confirmation
                    Console.WriteLine($"You are going to process {finalPrice}\n---------------------------------");
                    Console.WriteLine("Please Enter to Process");
                    Console.WriteLine("---------------------------------");
                    Console.ReadLine();

                    //Success message or Validation message
                    AuthorizePayment(finalPrice, money);

                    break;

                case "Credit Card":

                    //Credit Card input
                    Console.WriteLine("Please Enter your Credit Card number");
                    string creditCardNumberInput = Console.ReadLine();

                    decimal creditCardNumber;
                    bool isValidCreditCardNumber = decimal.TryParse(creditCardNumberInput, out creditCardNumber);

                    //Call Pay function overload to validate credit card, ask and validate cvv code, and return final price with taxes
                    Pay(isValidCreditCardNumber, creditCardNumberInput, price, out int finalPriceCreditCard);

                    Console.WriteLine($"You are going to process {finalPriceCreditCard}\n---------------------------------");
                    Console.WriteLine("Please Enter to Process");
                    Console.WriteLine("---------------------------------");
                    Console.ReadLine();

                    AuthorizePayment(finalPriceCreditCard, money);


                    break;
            }



        }

        public static void Pay(string emailInput, int price, out int finalPrice)
        {
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

            finalPrice = price - (price * 3 / 100);


        }

        public static void Pay(bool isValid, string creditCardInput, int price, out int finalPriceCreditCard)
        {
            while (creditCardInput.Length != 16)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a 16 length number");

                Console.ResetColor();
                creditCardInput = Console.ReadLine();
            }

            Console.WriteLine("Please enter your cvv code");
            int cvvCode;
            string cvvInput = Console.ReadLine();
            bool isValidCvv = int.TryParse(cvvInput, out cvvCode);

            while (!isValidCvv || cvvInput.Length != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again");
                Console.ResetColor();

                cvvInput = Console.ReadLine();
                isValidCvv = int.TryParse(cvvInput, out cvvCode);
            }

            finalPriceCreditCard = price + 2;

        }

        public static string PaymentMethod()
        {
            string method = Console.ReadLine();
            bool isValidMethod = method.Equals("PayPal") || method.Equals("Credit Card");

            //Validate Payment Methods
            while (!isValidMethod)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use valid method");

                Console.ResetColor();
                method = Console.ReadLine();
                isValidMethod = method.Equals("PayPal") || method.Equals("Credit Card");
            }

            return method;
        }

        public static void AuthorizePayment(int amount, int availableMoney)
        {
            if (amount > availableMoney)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Your payment failed due to insufficient funds");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Consgratulations. You have successfully made a payment");
            }
        }

        /*
         If Statement
         Switch case Statement
         While Loop
         Do While Loop
         For Loop
         Methods
         Methods Overloading
         ref out params
         Regex
         TryParse method
         Data Types
        */
    }
}