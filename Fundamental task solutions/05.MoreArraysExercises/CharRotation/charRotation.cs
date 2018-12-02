using System;
using System.Linq;
namespace CharRotation
{
    public class charRotation
    {
        public static void Main()
        {
            string chars = Console.ReadLine();
            int[] number = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string toString = string.Empty;

            for (int i = 0; i < chars.Length; i++)
            {
                int sign = chars[i];
                toString += number[i] % 2 == 0 ? (char)(sign - number[i]) : (char)(sign + number[i]);
            }
            Console.WriteLine(toString);
        }
    }
}
