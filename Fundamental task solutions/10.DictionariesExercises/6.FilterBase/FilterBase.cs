namespace _6.FilterBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FilterBase
    {
        public static void Main()
        {
            var usersByAge = new Dictionary<string, int>();
            var usersBySelary = new Dictionary<string, double>();
            var usersByPlace = new Dictionary<string, string>();
            var input = Console.ReadLine();
            while (input != "filter base")
            {
                var temporary = input.Split(' ').ToArray();
                var first = temporary[0];
                var last = temporary[temporary.Length - 1];

                var integer = 0;
                var flotingpoint = 0.0;
               
                if (int.TryParse(last, out integer))
                {
                    usersByAge[first] = integer;
                }
                else if (double.TryParse(last, out flotingpoint))
                {
                    usersBySelary[first] = flotingpoint;
                }
                else
                {
                    usersByPlace[first] = last;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            if (input == "Age")
            {
                foreach (var item in usersByAge)
                {
                    Console.WriteLine($"Name: {item.Key}\nAge: {item.Value}");
                    Console.WriteLine(new string('=', 20));
                }
            }
            else if (input == "Salary")
            {
                foreach (var item in usersBySelary)
                {
                    Console.WriteLine($"Name: {item.Key}\nSalary: {item.Value.ToString("0.00")}");
                    Console.WriteLine(new string('=', 20));
                }
            }
            else
            {
                foreach (var item in usersByPlace)
                {
                    Console.WriteLine($"Name: {item.Key}\nPosition: {item.Value}");
                    Console.WriteLine(new string('=', 20));
                }
            }
        }
    }
}