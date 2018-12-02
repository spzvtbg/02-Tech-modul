using System;
using System.Linq;

public class EnduranceRally
{
    static string[] drivers;
    static double[] zones;
    static int[] checkPoints;

    static double currentDriverPower;

    public static void Main()
    {
        drivers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        zones = ConvertToDouble(Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        checkPoints = ConvertToInt(Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        CheckPointsRegistriren();
        DriversTrougthRally();
        PrintAllDriversConditions();
    }

    static void PrintAllDriversConditions()
    {
        for (int index = 0; index < drivers.Length; index++)
        {
            var driverCondition = drivers[index].Split(' ');
            var driver = driverCondition[0];
            var quantity = Convert.ToDouble(driverCondition[1]);
            var reached = driverCondition[2];
            Console.WriteLine(
                reached == "1" ?
                $"{driver} - fuel left {quantity:F2}" :
                $"{driver} - reached {quantity}");
        }
    }

    static void CheckPointsRegistriren()
    {
        for (int index = 0; index < zones.Length; index++)
        {
            if (!checkPoints.Contains(index))
            {
                zones[index] *= -1;
            }
        }
    }

    static void DriversTrougthRally()
    {
        for (int index = 0; index < drivers.Length; index++)
        {
            currentDriverPower = drivers[index][0];
            for (int count = 0; count < zones.Length; count++)
            {
                currentDriverPower += zones[count];
                if (currentDriverPower <= 0)
                {
                    drivers[index] += $" {count} {0}";
                    break;
                }
            }
            if (currentDriverPower > 0)
            {
                drivers[index] += $" {currentDriverPower} {1}";
            }
        }
    }

    static double[] ConvertToDouble(string[] zonesAsString)
    {
        var zonesAsDouble = new double[zonesAsString.Length];
        for (int index = 0; index < zonesAsString.Length; index++)
        {
            zonesAsDouble[index] = Convert.ToDouble(zonesAsString[index]);
        }
        return zonesAsDouble;
    }

    static int[] ConvertToInt(string[] checkPointsAsString)
    {
        var checkPointsAsIntegers = new int[checkPointsAsString.Length];
        for (int index = 0; index < checkPointsAsString.Length; index++)
        {
            checkPointsAsIntegers[index] = Convert.ToInt32(checkPointsAsString[index]);
        }
        return checkPointsAsIntegers;
    }
}
