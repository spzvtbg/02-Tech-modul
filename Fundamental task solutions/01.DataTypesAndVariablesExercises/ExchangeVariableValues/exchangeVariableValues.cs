using System;
namespace ExchangeVariableValues
{
    public class exchangeVariableValues
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine()); 
            int b = int.Parse(Console.ReadLine()); 
            int a1 = b;
            int b1 = a;
            Console.WriteLine(a1);
            Console.WriteLine(b1);
        }
    }
}
