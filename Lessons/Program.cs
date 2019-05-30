using System;
using Lessons.Payouts;

namespace Lessons
{
    class Program
    {
        static void Main()
        {
            /*
            bool isMarried = false;  // 1bit
            string name = "Armen"; // 2 bytes for each character - 10 byte = 80 bit
            byte color = 255; // 1 byte == 8 bit
            int id = 412234; //4 byte == 32 bit (int32)
            short id1 = 12315; // 2 byte == 16 bit (int16)
            long id2 = 1231516143456465454; // 8 byte == 64 bit (int64)
            float amount = 4.34f; // 4 byte
            double amount1 = 4.34; // 8 byte
            decimal amount2 = 3.123m; // 16 byte
            char symbol = 'a'; // 2 byte == 16 bit

            Console.WriteLine(isMarried.ToString());     
            */

            bool isRafayel = false;
            bool isArmenian = true;

            Console.WriteLine(isRafayel.ToString().ToLower());
            Console.WriteLine(isArmenian.ToString().ToLower());

        }
    }
}
