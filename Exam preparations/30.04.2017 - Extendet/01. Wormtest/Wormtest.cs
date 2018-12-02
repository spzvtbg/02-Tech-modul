using System;

public class Wormtest
{
    public static void Main()
    {
        var wormLingthInMeters = Convert.ToInt32(Console.ReadLine());
        var wormWidhtInCentimeters = Convert.ToDecimal(Console.ReadLine());

        var currentWormLength = wormLingthInMeters * 100;
        var remainder = 0m;
        try
        {
            remainder = currentWormLength % wormWidhtInCentimeters;
        }
        catch (Exception)
        {
            remainder = 0;
        }

        if (remainder == 0)
        {
            Console.WriteLine("{0:F2}", currentWormLength * wormWidhtInCentimeters);
        }
        else
        {
            Console.WriteLine("{0:F2}%", currentWormLength / wormWidhtInCentimeters * 100);
        }
    }
}
