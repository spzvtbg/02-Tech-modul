using System;
using System.Linq;

public class Ladybugs
{
    static string[] currentBugsField;


    static string direction;
    static long fromIndex;
    static long moves;

    public static void Main()
    {
        var numberOfBugsFields = Convert.ToInt64(Console.ReadLine());
        currentBugsField = new string[numberOfBugsFields];

        var bugsIndexes = ConvertToIntegers(Console.ReadLine().Split(' '));
        PutAllBugsInTheirFieldsFrom(bugsIndexes);

        ReadNextLinesUntilEndFrom(Console.ReadLine());
        PrintLeftBugs();
    }

    private static void PrintLeftBugs()
    {
        var isFirst = true;
        foreach (var item in currentBugsField)
        {
            if (isFirst)
            {
                isFirst = false;
                Console.Write(item);
                continue;
            }
            Console.Write(" {0}", item);
        }
        Console.WriteLine();
    }

    static long[] ConvertToIntegers(string[] indexes)
    {
        var currentIndexes = new long[indexes.Length];
        for (int index = 0; index < indexes.Length; index++)
        {
            currentIndexes[index] = Convert.ToInt64(indexes[index]);
        }
        return currentIndexes;
    }

    static void PutAllBugsInTheirFieldsFrom(long[] bugsIndexes)
    {
        for (int index = 0; index < currentBugsField.Length; index++)
        {
            if (bugsIndexes.Contains(index))
            {
                currentBugsField[index] = "1";
            }
            else currentBugsField[index] = "0";
        }
    }

    static void ReadNextLinesUntilEndFrom(string input)
    {
        if (input != "end")
        {
            SplitGiven(input);
            if (IsValidIndex())
            {
                MoveCurrentBug();
            }
            ReadNextLinesUntilEndFrom(Console.ReadLine());
        }
        else return;
    }

    static void MoveCurrentBug()
    {
        if (currentBugsField[fromIndex] == "1")
        {
            currentBugsField[fromIndex] = "0";
            moves *= direction == "left" ? -1 : 1;
            while (IsValidIndex())
            {
                fromIndex += moves;
                if (IsValidIndex() && currentBugsField[fromIndex] == "0")
                {
                    currentBugsField[fromIndex] = "1"; break;
                }
                else continue;
            }
        }
        else return;
    }

    static bool IsValidIndex()
    {
        return fromIndex >= 0 && fromIndex <= currentBugsField.Length - 1;
    }

    static void SplitGiven(string input)
    {
        var splited = input.Split(' ');
        direction = splited[1];
        fromIndex = Convert.ToInt64(splited[0]);
        moves = Convert.ToInt64(splited[2]);
    }
}
