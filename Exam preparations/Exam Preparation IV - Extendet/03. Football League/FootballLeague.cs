using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Team
{
    private string teamName;
    private long teamScore;
    private long goals;

    public Team(string teamName, long teamScore, long goals)
    {
        this.teamName = teamName;
        this.teamScore = teamScore;
        this.goals = goals;
    }

    public string TeamName
    {
        get { return teamName; }
        set { this.teamName = value; }
    }

    public long TeamScore
    {
        get { return teamScore; }
        set { this.teamScore = value; }
    }

    public long Goals
    {
        get { return goals; }
        set { this.goals = value; }
    } 

    public override string ToString()
    {
        return $"{TeamName} {TeamScore}";
    }
}

public class FootballLeague
{
    static string key;
    static string pattern;

    static string firstTeam;
    static long firstTeamScore;
    static long firstTeamGoals;

    static string lastTeam;
    static long lastTeamScore;
    static long lastTeamGoals;

    static List<Team> teamsCollection = new List<Team>();

    public static void Main()
    {
        key = Regex.Escape(Console.ReadLine());
        pattern = $@".*?({key})(?<team1>\w*)({key}).*?({key})(?<team2>\w*)({key}).*?(?<score>\d+:\d+).*?";

        ReadNextInputLinesFrom(Console.ReadLine());

        PrintLegueStatistic();
        PrintFirstThreeFromLegue();
    }

    static void ReadNextInputLinesFrom(string teamsAndScore)
    {
        if (teamsAndScore != "final")
        {
            DivideAndRule(teamsAndScore);
            ReadNextInputLinesFrom(Console.ReadLine());
        }
        else return;
    }

    static void DivideAndRule(string teamsAndScore)
    {
        var teamsMatcher = new Regex($@"{pattern}");
        var teamsResults = teamsMatcher.Match(teamsAndScore);
        if (teamsMatcher.IsMatch(teamsAndScore))
        {
            SplitAndParse(teamsResults);
            AddOrUpdateCurrentTeams(firstTeam, firstTeamScore, firstTeamGoals);
            AddOrUpdateCurrentTeams(lastTeam, lastTeamScore, lastTeamGoals);
        }
    }

    static void SplitAndParse(Match teamsResults)
    {
        var matchResult = teamsResults.Groups["score"].Value
                        .Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
        firstTeamGoals = Convert.ToInt64(matchResult[0]);
        lastTeamGoals = Convert.ToInt64(matchResult[1]);

        TakePoints(matchResult);

        firstTeam = string.Join("", teamsResults.Groups["team1"].Value.ToUpper().Reverse().ToArray());
        firstTeamScore = Convert.ToInt64(matchResult[0]);

        lastTeam = string.Join("", teamsResults.Groups["team2"].Value.ToUpper().Reverse().ToArray());
        lastTeamScore = Convert.ToInt64(matchResult[1]);
    }

    static void TakePoints(string[] matchResult)
    {
        var first = Convert.ToInt64(matchResult[0]);
        var second = Convert.ToInt64(matchResult[1]);

        if (first > second)
        {
            matchResult[0] = "3";
            matchResult[1] = "0";
        }
        else if (first < second)
        {
            matchResult[0] = "0";
            matchResult[1] = "3";
        }
        else if (first == second)
        {
            matchResult[0] = "1";
            matchResult[1] = "1";
        }
    }

    static void AddOrUpdateCurrentTeams(string team, long score, long goals)
    {
        if (teamsCollection.Any(x => x.TeamName == team))
        {
            var currentTeam = teamsCollection.Where(x => x.TeamName == team).First();
            currentTeam.TeamScore += score;
            currentTeam.Goals += goals;
        }
        else
        {
            var newTeam = new Team(team, score, goals);
            teamsCollection.Add(newTeam);
        }
    }

    static void PrintLegueStatistic()
    {
        var count = 0;
        Console.WriteLine("League standings:");
        foreach (var team in teamsCollection.OrderByDescending(x => x.TeamScore).ThenBy(x => x.TeamName))
        {
            count++;
            Console.WriteLine($"{count}. {team.ToString()}");
        }
    }

    static void PrintFirstThreeFromLegue()
    {
        Console.WriteLine("Top 3 scored goals:");
        foreach (var team in teamsCollection.OrderByDescending(x => x.Goals).ThenBy(x => x.TeamName).Take(3))
        {
            Console.WriteLine($"- {team.TeamName} -> {team.Goals}");
        }
    }
}
