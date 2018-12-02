using System;
namespace TrickyStrings
{
    public class concatenateStrings
    {
        public static void Main()
        {
            string delimiter = Console.ReadLine();
            int lenght = int.Parse(Console.ReadLine());

            string[] endString = new string[lenght * 2 - 1];

            for (int i = 0; i < endString.Length; i++)
            {
                endString[i] = i % 2 == 0 ? Console.ReadLine(): delimiter;
            }
            for (int i = 0; i < endString.Length; i++)
            {
                Console.Write(endString[i] + "");
            }
            Console.WriteLine();
        }
    }
}
