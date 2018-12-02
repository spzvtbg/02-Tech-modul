namespace _01.SoftuniCoffeeOrders
{
    using System;
    using System.Globalization;
  
    public class SoftuniCoffeeOrders
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var total = 0.0M;

            for (int i = 0; i < linesCount; i++)
            {
                var price = decimal.Parse(Console.ReadLine());

                var date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);

                var capsules = long.Parse(Console.ReadLine());

                var days = DateTime.DaysInMonth(date.Year, date.Month);

                var result = days * capsules * price;

                total += result;

                Console.WriteLine($"The price for the coffee is: ${result:F2}");
            }

            Console.WriteLine($"Total: ${total:F2}");
        }
    }
}
