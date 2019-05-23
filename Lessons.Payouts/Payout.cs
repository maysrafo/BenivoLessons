using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Payouts
{
    public class Payout
    {
        public static void Withdraw(int amount)
        {
            Console.WriteLine($"Your {amount}$ is withdrawn successfully ");
        }
    }
}
