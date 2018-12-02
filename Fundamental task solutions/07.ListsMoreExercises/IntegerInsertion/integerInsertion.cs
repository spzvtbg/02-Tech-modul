using System;
using System.Linq;
using System.Collections.Generic;
namespace IntegerInsertion
{
    public class integerInsertion
    {
        public static void Main()
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            input = PasteTheEnters(input);
            Console.WriteLine(string.Join(" ", input));
        }

        private static List<int> PasteTheEnters(List<int> input)
        {
            string enter = Console.ReadLine();
            while (enter != "end")
            {
                int digit = TakeDigit(enter);
                input.Insert(digit, int.Parse(enter));
                enter = Console.ReadLine();
            }
            return input;
        }

        private static int TakeDigit(string enter)
        {
            int n = enter.Length - 1;
            string divider = "1" + new string('0', n);
            int digit = int.Parse(enter) / int.Parse(divider);
            return digit;
        }
    }
}
