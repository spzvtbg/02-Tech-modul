using System;
namespace VariableInHexadecimalFormat
{
    public class printInDecimal
    {
        public static void Main()
        {
            string hexNumber = Console.ReadLine();
            int inDecimal = Convert.ToInt32(hexNumber, 16);
            Console.WriteLine(inDecimal);
        }
    }
}
