using System;

public class Wormhole
{
    public static void Main()
    {
        var stepCounter = 0;
        var holes = ConvertToIntegers(Console.ReadLine().Split(' '));
        for (int index = 0; index < holes.Length; index++)
        {
            if (holes[index] != 0)
            {
                var temp = holes[index];
                holes[index] = 0;
                index = temp;
            }
            stepCounter++;
        }
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
}
