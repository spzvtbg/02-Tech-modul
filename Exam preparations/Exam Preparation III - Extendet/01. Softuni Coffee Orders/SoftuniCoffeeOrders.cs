using System;
using System.Globalization;

public class SoftuniCoffeeOrders
{
    static int orders;

    static decimal pricePerCapsule;
    static DateTime orderDate; /// 25/11/2016, 7/03/2016, 1/1/2020
    static long capsules;

    static decimal totalPrice;

    public static void Main()
    {
        orders = Convert.ToInt16(Console.ReadLine());
        ReadNextOrdersFromConsole();
        Console.WriteLine($"Total: ${totalPrice:F2}");
    }

    static void ReadNextOrdersFromConsole()
    {
        if (orders > 0)
        {
            orders -= 1;
            pricePerCapsule = Convert.ToDecimal(Console.ReadLine());
            orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            capsules = Convert.ToInt64(Console.ReadLine());

            CalculateAndPrint();
            ReadNextOrdersFromConsole();
        }
        else return;
    }

    private static void CalculateAndPrint()
    {
        var days = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
        var price = capsules * days * pricePerCapsule;
        Console.WriteLine($"The price for the coffee is: ${price:F2}");
        totalPrice += price;
    }
}
