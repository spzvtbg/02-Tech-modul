using System;
using System.Collections.Generic;
using System.Linq;

class Legion
{
    public int LastActivity { get; set; }
    public string LegionName { get; set; }
    public List<LegionTypes> Soldiers { get; set; }
}

class LegionTypes
{
    public string SoldierType { get; set; }
    public long SoldierCount { get; set; }
}

public class HornetArmada
{
    static int activity;
    static string name;
    static string type;
    static long count;

    static string input = string.Empty;
    static List<Legion> hornetLegions = new List<Legion>();

    public static void Main()
    {
        var commingLines = Convert.ToInt32(Console.ReadLine());
        ReadNextInputLines(ref commingLines);
        ReadPrintingCommandFrom(Console.ReadLine().Split('\\'));
    }

    static void ReadPrintingCommandFrom(string[] commands)
    {
        if (commands.Length == 1)
        {
            PrintLegionsWithGivenSoldierType(commands[0]);
            return;
        }
        else
        {
            PrintSoldiersFromLowerLastActivity(commands);
        }
    }

    static void PrintSoldiersFromLowerLastActivity(string[] commands)
    {
        activity = Convert.ToInt32(commands[0]);
        type = commands[1];
        var output = hornetLegions
            .Where(x => x.LastActivity < activity).ToDictionary(x => x.LegionName, x => x.Soldiers
            .Where(s => s.SoldierType == type).ToDictionary(s => s.SoldierType, s => s.SoldierCount))
            .OrderByDescending(x => x.Value.Values.FirstOrDefault());
        foreach (var name in output)
        {
            foreach (var item in name.Value)
            {
                Console.WriteLine($"{name.Key} -> {item.Value}");
            }
        }
    }

    static void PrintLegionsWithGivenSoldierType(string type)
    {
        foreach (var item in hornetLegions.OrderByDescending(x => x.LastActivity))
        {
            if (item.Soldiers.Any(x => x.SoldierType == type))
            {
                Console.WriteLine($"{item.LastActivity} : {item.LegionName}");
            }
        }
    }

    static void ReadNextInputLines(ref int commingLines)
    {
        if (commingLines >= 1)
        {
            commingLines--;
            input = Console.ReadLine();
            SplitCurrentInput();
            ParseSplitedInputToTheLegion();
            ReadNextInputLines(ref commingLines);
        }
        else return;
    }

    static void SplitCurrentInput()
    {
        var splitedInput = input.Split(new[] { " = ", " -> ", ":" }
        , StringSplitOptions.RemoveEmptyEntries);
        activity = Convert.ToInt32(splitedInput[0]);
        name = splitedInput[1];
        type = splitedInput[2];
        count = Convert.ToInt64(splitedInput[3]);
    }

    static void ParseSplitedInputToTheLegion()
    {
        if (!hornetLegions.Any(x => x.LegionName == name))
        {
            AddNewLegion();
        }
        else
        {
            UpdateCurrentLegion();
        }
    }

    static void AddNewLegion()
    {
        var newLegion = new Legion();
        newLegion.LegionName = name;
        newLegion.LastActivity = activity;
        newLegion.Soldiers = new List<LegionTypes>();
        var newType = new LegionTypes();
        newType.SoldierType = type;
        newType.SoldierCount = count;
        newLegion.Soldiers.Add(newType);
        hornetLegions.Add(newLegion);
    }

    static void UpdateCurrentLegion()
    {
        var currentLegion = hornetLegions.Where(x => x.LegionName == name).First();
        var newType = new LegionTypes();

        if (currentLegion.Soldiers.Any(x => x.SoldierType == type))
        {
            var currentType = currentLegion.Soldiers.Where(x => x.SoldierType == type).First();
            currentType.SoldierCount += count;
        }
        else
        {
            newType.SoldierType = type;
            newType.SoldierCount = count;
            currentLegion.Soldiers.Add(newType);
        }

        if (currentLegion.LastActivity < activity)
        {
            currentLegion.LastActivity = activity;
        }
    }
}