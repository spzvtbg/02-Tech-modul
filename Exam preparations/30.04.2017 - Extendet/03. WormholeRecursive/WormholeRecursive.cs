using System;

public class WormholeRecursive
{
    static int stepCounter = 0;
    static int currentIndex = 0;
    static int[] holes;

    public static void Main()
    {
        holes = ConvertToIntegers(Console.ReadLine().Split(' '));
        GoThroughCurrentArray();
        Console.WriteLine(stepCounter);
    }

    private static int[] ConvertToIntegers(string[] input)
    {
        var temporaryArray = new int[input.Length];
        for (int index = 0; index < input.Length; index++)
        {
            temporaryArray[index] = Convert.ToInt32(input[index]);
        }
        return temporaryArray;
    }

    static void GoThroughCurrentArray()
    {
        if (currentIndex <= holes.Length - 1)
        {
            stepCounter++;
            if (holes[currentIndex] != 0)
            {
                var temp = holes[currentIndex];
                holes[currentIndex] = 0;
                currentIndex = temp;
            }
            currentIndex++;
            GoThroughCurrentArray();
        }
        else return;
    }
}
