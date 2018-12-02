using System;
using System.Collections.Generic;

public class Entertrain
{
    static long locomotivsPower;
    static long compositionSum;

    static List<long> composition = new List<long>();

    public static void Main()
    {
        locomotivsPower = Convert.ToInt64(Console.ReadLine());
        ReadNextLinesFrom(Console.ReadLine());
        composition.Reverse();
        composition.Add(locomotivsPower);
        Console.WriteLine(string.Join(" ", composition));
    }

    public static void ReadNextLinesFrom(string input)
    {
        if (input != "All ofboard!")
        {
            var currentWagoon = Convert.ToInt64(input);
            compositionSum += currentWagoon;
            composition.Add(currentWagoon);

            if (compositionSum > locomotivsPower)
            {
                var average = compositionSum / composition.Count;
                var closestElement = FindClosestElementTo(average);
                composition.Remove(closestElement);
                compositionSum -= closestElement;
            }

            ReadNextLinesFrom(Console.ReadLine());
        }
    }

    public static long FindClosestElementTo(long average)
    {
        var diference = long.MaxValue;
        var closestElement = 0L;

        for (int i = 0; i < composition.Count; i++)
        {
            var temporaryDifernce = Math.Abs(composition[i] - average);
            if (temporaryDifernce < diference)
            {
                closestElement = composition[i];
                diference = temporaryDifernce;
            }
        }
        return closestElement;
    }
}
