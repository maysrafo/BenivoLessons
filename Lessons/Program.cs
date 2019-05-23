using System;
using Lessons.Payments;
using Lessons.Payouts;

namespace Lessons
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World");

            PayPal.Pay(100);
            PayPal.Pay(50);
            PayPal.Pay(200);

            Payout.Withdraw(150);
            Payout.Withdraw(250);
            Payout.Withdraw(350);
        }
    }
}
