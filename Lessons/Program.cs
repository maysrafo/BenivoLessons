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
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Number{i + 1} = ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int x = numbers[0];
            int y = numbers[0];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                if (numbers[i] > x)
                {
                    x = numbers[i];
                    index = i;

                }                
            }

            for (int j = 0; j < n; j++)
            {
                if (numbers[j] >= y && j != index)
                {
                    y = numbers[j];
                }
            }

            Console.WriteLine();
            Console.WriteLine($"maxValue = {x}");
            Console.WriteLine($"secondMaxValue = {y}");

        }

    }
}
