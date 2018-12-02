using System;
using System.Collections.Generic;
using System.Linq;

public class CottageScraper
{
    static string tree = string.Empty;
    static int length = 0;
    static double sum = 0;
    static int count = 0;

    static Dictionary<string, List<int>> treeKindsAndLengths =
        new Dictionary<string, List<int>>();

    public static void Main()
    {
        ReadNextTreeKindsWhitTheirLength(Console.ReadLine());
        TakeWathNeededAndPrint(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
    }

    static void ReadNextTreeKindsWhitTheirLength(string givenTreeKindAndLength)
    {
        if (givenTreeKindAndLength != "chop chop")
        {
            DivideAndRule(givenTreeKindAndLength);
            AddToTreeKindsAndLengths();
            ReadNextTreeKindsWhitTheirLength(Console.ReadLine());
        }
        else return;
    }

    static void DivideAndRule(string givenTreeKindAndLength)
    {
        var splitedTreeKindAndLength = givenTreeKindAndLength.Split(' ');
        tree = splitedTreeKindAndLength[0];
        length = Convert.ToInt32(splitedTreeKindAndLength[2]);
    }

    static void AddToTreeKindsAndLengths()
    {
        if (!treeKindsAndLengths.ContainsKey(tree))
        {
            treeKindsAndLengths[tree] = new List<int>();
        }
        treeKindsAndLengths[tree].Add(length);
        sum += length;
        count++;
    }

    static void TakeWathNeededAndPrint(string treeKind, int neededLength)
    {
        var priceLM = Math.Round(treeKindsAndLengths.Values.Sum(d => d.Sum()) / (double)count, 2);
        Console.WriteLine($"Price per meter: ${priceLM:0.00}");

        var used = Math.Round(treeKindsAndLengths[treeKind]
            .Where(x => x >= neededLength).Sum() * priceLM, 2);
        Console.WriteLine($"Used logs price: ${used:0.00}");

        var unused = Math.Round((treeKindsAndLengths[treeKind].Where(x => x < neededLength).Sum() +
            treeKindsAndLengths.Values.Sum(x => x.Sum()) - 
            treeKindsAndLengths[treeKind].Sum()) * priceLM * 0.25, 2);
        Console.WriteLine($"Unused logs price: ${unused:0.00}");

        Console.WriteLine($"CottageScraper subtotal: ${(used + unused):0.00}");
    }
}
