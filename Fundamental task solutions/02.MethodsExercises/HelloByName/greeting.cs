using System;
namespace HelloByName
{
    public class greeting
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            GreetingByName(name);
        }

        private static void GreetingByName(string str)
        {
            Console.WriteLine($"Hello, {str}!");
        }
    }
}
