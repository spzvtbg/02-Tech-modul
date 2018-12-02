using System;

public class SerializeString
{
    static int symbolsCounter;
    static string someString;
    static string distinctSymbols;

    public static void Main()
    {
        someString = $@"{Console.ReadLine()}";
        distinctSymbols = FindAllDistinctSimbolsFromGivenString();
        symbolsCounter = distinctSymbols.Length;

        FindAndPrintCurrentSymbolAndHisIndexes();
    }

    static string FindAllDistinctSimbolsFromGivenString()
    {
        distinctSymbols = string.Empty;
        foreach (var item in someString)
        {
            if (!distinctSymbols.Contains(item.ToString()))
            {
                distinctSymbols += item;
            }
        }
        return distinctSymbols;
    }

    static void FindAndPrintCurrentSymbolAndHisIndexes()
    {
        for (int index = 0; index < symbolsCounter; index++)
        {
            var isFirst = true;
            var output = string.Empty;
            var currentSymbol = distinctSymbols[index];
            output += currentSymbol;

            for (int i = 0; i < someString.Length; i++)
            {
                i = someString.IndexOf(currentSymbol, i);
                if (i > -1 || i < -1)
                {
                    output += isFirst ? $":{i}" : $"/{i}";
                    isFirst = false;
                }
                else break;
            }
            Console.WriteLine(output);
        }
    }
}