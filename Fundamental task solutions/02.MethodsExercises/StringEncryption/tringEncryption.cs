using System;
namespace StringEncryption
{
    public class tringEncryption
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());
                result += Enkript(input);
            }
            Console.WriteLine(result);
        }

        private static string Enkript(char a)
        {
            int number = (int)a;
            int second = number;
            while (second >= 10)
            {
                second /= 10;
            }
            int third = number % 10;
            char first = (char)(number + third);
            char last = (char)(number - second);
            string text = first.ToString() + second.ToString() + third.ToString() + last.ToString();
            return text;
        }
    }
}
