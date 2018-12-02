using System;
using System.Collections.Generic;
using System.Linq;

public class WormsWorldParty
{
    static int score = 0;
    static string team = string.Empty;
    static string name = string.Empty;

    static Dictionary<string, Dictionary<string, long>> wormTeams =
        new Dictionary<string, Dictionary<string, long>>();

    public static void Main()
    {
        ReadSeveralInputLines(Console.ReadLine());
        PrintResultInGivenOrder();
    }

    static void ReadSeveralInputLines(string teamData)
    {
        if (teamData != "quit")
        {
            Parse(teamData);
            AddToWormTeams();
            ReadSeveralInputLines(Console.ReadLine());
        }
        else return;
    }

    static void Parse(string teamData)
    {
        var splited = teamData.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            score = Convert.ToInt32(splited[2]);
            team = splited[1];
            name = splited[0];
    }

    static void AddToWormTeams()
    {
        if (!wormTeams.Any(x => x.Value.ContainsKey(name)))
        {
            if (!wormTeams.ContainsKey(team))
            {
                wormTeams[team] = new Dictionary<string, long>();
            }
            if (!wormTeams[team].ContainsKey(name))
            {
                wormTeams[team][name] = 0;
            }
            wormTeams[team][name] = score;
        }
    }

    static void PrintResultInGivenOrder()
    {
        var counter = 1;
        foreach (var team in wormTeams.OrderByDescending(x => x.Value.Values.Sum())
            .ThenByDescending(x => x.Value.Values.Average()))
        {
            Console.WriteLine($"{counter}. Team: {team.Key} - {wormTeams[team.Key].Values.Sum()}");
            foreach (var name in wormTeams[team.Key].OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"###{name.Key} : {name.Value}");
            }
            counter++;
        }
    }
}
