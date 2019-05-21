using System;
using Lessons.Payments;

namespace Lessons
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World");

            PayPal.Pay(100);
            PayPal.Pay(50);

        }
    }
}
