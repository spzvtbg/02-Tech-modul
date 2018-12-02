using System;
namespace ASCIItoString
{
    public class convertingAskiiCode
    {
        public static void Main()
        {
            int loopLenght = int.Parse(Console.ReadLine());

            char[] chars = new char[loopLenght];
            int ints = 0;
            for (int i = 0; i < loopLenght; i++)
            {
                ints = int.Parse(Console.ReadLine());
                chars[i] = (char)ints;
            }
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
            }
            Console.WriteLine();
        }
    }
}