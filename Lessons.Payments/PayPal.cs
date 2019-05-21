using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Payments
{
    public class PayPal
    {
       public static void Pay(int amount)
        {
            Console.WriteLine("Paid " + amount + " successfully with PayPal");
            Console.WriteLine($"Paid {amount} successfully with PayPal");
        }
    }
}
