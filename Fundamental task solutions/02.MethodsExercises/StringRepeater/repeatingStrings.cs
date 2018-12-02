using System;
namespace StringRepeater
{
    public class repeatingStrings
    {
        public static void Main()
        {
            string str = Console.ReadLine();
            int repeatingTimes = int.Parse(Console.ReadLine());

            RepeatingStrings(str, repeatingTimes);
        }

        private static void RepeatingStrings(string str, int n)
        {
            for (int i = 1; i  <= n; i ++)
            {
                Console.Write(str);
            }
            Console.WriteLine();
        }
    }
}
