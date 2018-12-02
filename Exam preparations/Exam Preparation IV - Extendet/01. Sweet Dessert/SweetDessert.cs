using System;

public class SweetDessert
{
    public static void Main()
    {
        double ivanchosMoney = double.Parse(Console.ReadLine());

        long guests = long.Parse(Console.ReadLine());

        double bananaPrice = double.Parse(Console.ReadLine());

        double eggPrice = double.Parse(Console.ReadLine());

        double berrysPricePerKg = double.Parse(Console.ReadLine());

        double priceForSixPortions = 2 * bananaPrice + 4 * eggPrice + berrysPricePerKg / 5;

        int portions = (int)Math.Ceiling(guests / 6.00);

        double totalDesertPrice = portions * priceForSixPortions;

        double totalMoney = Math.Abs(ivanchosMoney - totalDesertPrice);

        if (ivanchosMoney >= totalDesertPrice)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {totalDesertPrice:F2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalMoney:F2}lv more.");
        }
    }
}
