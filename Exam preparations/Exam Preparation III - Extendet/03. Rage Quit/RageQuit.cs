using System;
using System.Linq;
using System.Text;

public class RageQuit
{
    static string[] strings;
    static int[] counts;

    static StringBuilder stringBuilder = new StringBuilder();

    public static void Main()
    {
        ReadGivenRageQuitFrom(Console.ReadLine());
    }

    private static void ReadGivenRageQuitFrom(string rageQuit)
    {
        TakeStrings(rageQuit);
        TakeCounts(rageQuit);
        MakeResultString();
        PrintResult(rageQuit);
    }

    static void PrintResult(string rageQuit)
    {
        Console.WriteLine($"Unique symbols used: {stringBuilder.ToString().Distinct().Count()}");
        Console.WriteLine(stringBuilder);
    }

    static void TakeStrings(string rageQuit)
    {
        for (int index = 0; index < rageQuit.Length; index++)
        {
            if (rageQuit[index] < '0' || rageQuit[index] > '9')
            {
                stringBuilder.Append(rageQuit[index]);
            }
            else stringBuilder.Append("<<=>>");
        }
        strings = stringBuilder.ToString().Split(new[] { "<<=>>" }, StringSplitOptions.RemoveEmptyEntries); 
    }

    static void TakeCounts(string rageQuit)
    {
        stringBuilder = new StringBuilder();
        for (int index = 0; index < rageQuit.Length; index++)
        {
            if (rageQuit[index] >= '0' && rageQuit[index] <= '9')
            {
                stringBuilder.Append(rageQuit[index]);
            }
            else stringBuilder.Append(" ");
        }
        counts = ConvertToIntegers(
            stringBuilder.ToString().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
    }

    static int[] ConvertToIntegers(string[] strings)
    {
        var ints = new int[strings.Length];
        for (int index = 0; index < strings.Length; index++)
        {
            ints[index] = Convert.ToInt32(strings[index]);
        }
        return ints;
    }

    static void MakeResultString()
    {
        stringBuilder = new StringBuilder();
        for (int index = 0; index < strings.Length; index++)
        {
            for (int count = 0; count < counts[index]; count++)
            {
                stringBuilder.Append(strings[index].ToUpper());
            }
        }
    }
}
