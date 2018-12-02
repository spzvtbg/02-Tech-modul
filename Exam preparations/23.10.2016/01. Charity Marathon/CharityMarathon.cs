using System;

public class CharityMarathon
{
    public static void Main()
    {
        var daysForMaraton = Convert.ToInt16(Console.ReadLine());
        var numberOfRunners = Convert.ToInt64(Console.ReadLine());
        var averageNumberOfLaps = Convert.ToInt16(Console.ReadLine());
        var trackLenght = Convert.ToInt64(Console.ReadLine());
        var trackCapacity = Convert.ToInt16(Console.ReadLine());
        var moneyDonatedPerKilometer = Convert.ToDouble(Console.ReadLine());

        var allRunnersThatCanRunning = daysForMaraton * trackCapacity;
        if (numberOfRunners > allRunnersThatCanRunning)
        {
            numberOfRunners = allRunnersThatCanRunning;
        }

        var totalKilometer = (trackLenght * numberOfRunners * averageNumberOfLaps) / 1000.00;
        var raisedMoney = totalKilometer * moneyDonatedPerKilometer;

        Console.WriteLine("Money raised: {0:F2}", raisedMoney);
    }
}
