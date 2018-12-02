using System;
using System.Collections.Generic;
namespace MyTechModule1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            list.Insert(0, 1);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
