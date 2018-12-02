using System;

namespace DataOwerflow
{
    class Program
    {
        static void Main()
        {
            var first = decimal.Parse(Console.ReadLine());
            var second = decimal.Parse(Console.ReadLine());
            var smaller = Math.Min(first, second);
            var bigger = Math.Max(first, second);

            Console.WriteLine("bigger type: " + numType(bigger));
            Console.WriteLine("smaller type: " + numType(smaller));

            var smallerType = numType(smaller);
            decimal overflowCount = 0;

            switch (smallerType)
            {
                case "byte":
                    overflowCount = bigger / byte.MaxValue;
                    break;
                case "ushort":
                    overflowCount = bigger / ushort.MaxValue;
                    break;
                case "uint":
                    overflowCount = bigger / uint.MaxValue;
                    break;
                case "ulong":
                    overflowCount = bigger / ulong.MaxValue;
                    break;
                default:
                    overflowCount = 0;
                    break;
            }
            Console.WriteLine($"{bigger} can overflow {numType(smaller)} {Math.Round(overflowCount)} times");


        }

        private static string numType(decimal v)
        {
            return byte.MaxValue >= v ? "byte" : ushort.MaxValue >= v ? "ushort" : uint.MaxValue >= v ? "uint" : "ulong";
        }
    }
}