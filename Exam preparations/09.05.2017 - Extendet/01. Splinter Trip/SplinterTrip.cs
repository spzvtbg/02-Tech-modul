using System;

public class SplinterTrip
{
    public static void Main()
    {
        var distance = Convert.ToDecimal(Console.ReadLine());
        var  fuelCapacity = Convert.ToDecimal(Console.ReadLine());
        var spendMiles = Convert.ToDecimal(Console.ReadLine());

        var fuelInHeavyWinds = spendMiles * 25m * 1.5m;
        var fuelInNoneHeavyWinds = (distance - spendMiles) * 25m;

        var totalFuelNeeded = (fuelInNoneHeavyWinds + fuelInHeavyWinds) * 1.05m;
        Console.WriteLine($"Fuel needed: {totalFuelNeeded:F2}L");

        Console.WriteLine(totalFuelNeeded <= fuelCapacity ?
            $"Enough with {(fuelCapacity - totalFuelNeeded):F2}L to spare!" :
            $"We need {(totalFuelNeeded - fuelCapacity):F2}L more fuel.");
    }
}