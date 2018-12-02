using System;
using System.Collections.Generic;
using System.Linq;

class Participant
{
    public string Name { get; set; }
    public List<string> Award { get; set; }
}

public class SoftUniKaraoke
{
    static string[] participantsAppliedToPerformance;
    static string[] avilableSongsToPerformance;

    static string participant = string.Empty;
    static string award = string.Empty;

    static string singer = string.Empty;
    static string song = string.Empty;

    static List<Participant> allParticipantsWithValidAwards = new List<Participant>();

    public static void Main()
    {
        participantsAppliedToPerformance = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        avilableSongsToPerformance = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        ReadNextInputLinesFrom(Console.ReadLine());
        PrintAllParticipantsWithTheirAwards();
    }

    static void PrintAllParticipantsWithTheirAwards()
    {
        if (allParticipantsWithValidAwards.Count == 0)
        {
            Console.WriteLine("No awards"); return;
        }
        foreach (var participant in allParticipantsWithValidAwards
            .OrderByDescending(x => x.Award.Count).ThenBy(x => x.Name))
        {
            Console.WriteLine($"{participant.Name}: {participant.Award.Count} awards");
            foreach (var award in participant.Award.OrderBy(x => x))
            {
                Console.WriteLine($"--{award}");
            }
        }
    }

    static void ReadNextInputLinesFrom(string input)
    {
        if (input != "dawn")
        {
            SlitCurrent(input);
            AddCurrentParticipantWithAwardIfIsValid();
            ReadNextInputLinesFrom(Console.ReadLine());
        }
        else return;
    }

    static void AddCurrentParticipantWithAwardIfIsValid()
    {
        if (participantsAppliedToPerformance.Contains(participant) && avilableSongsToPerformance.Contains(song))
        {
            AddOrUpdeateCurrentParticipant();
        }
    }

    private static void AddOrUpdeateCurrentParticipant()
    {
        if (!allParticipantsWithValidAwards.Any(x => x.Name == participant))
        {
            var newParticipant = new Participant();
            newParticipant.Name = participant;
            newParticipant.Award = new List<string>();
            newParticipant.Award.Add(award);
            allParticipantsWithValidAwards.Add(newParticipant);
        }
        else UpdateCurrentParticipent();
    }

    static void UpdateCurrentParticipent()
    {
        var currentParticipant = allParticipantsWithValidAwards
            .Where(x => x.Name == participant).FirstOrDefault();
        if (!currentParticipant.Award.Contains(award))
        {
            currentParticipant.Award.Add(award);
        }
    }

    static void SlitCurrent(string input)
    {
        var splited = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        participant = splited[0];
        song = splited[1];
        award = splited[2];
    }
}
