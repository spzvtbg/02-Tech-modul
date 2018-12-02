using System;
using System.Collections.Generic;

public class Exercise
{
    public string Topic { get; set; }
    public string CourceName { get; set; }
    public string JudgeContestLink { get; set; }
    public string[] Problems { get; set; }

}

public class Program
{
    static string topic = string.Empty;
    static string course = string.Empty;
    static string contestLink = string.Empty;
    static string[] problems;

    static List<Exercise> givenInformation = new List<Exercise>();

    public static void Main()
    {
        ReadSeveralInputLinesFrom(Console.ReadLine());
        PrintResultByGivenOrder();
    }

    static void ReadSeveralInputLinesFrom(string currentInput)
    {
        if (currentInput != "go go go")
        {
            SplitAndParseToAllVariablesFrom(currentInput);
            AddToListWithGivenInformation();
            ReadSeveralInputLinesFrom(Console.ReadLine());
        }
        else return;
    }

    static void SplitAndParseToAllVariablesFrom(string currentInput)
    {
        var splitedInput = currentInput
            .Split(new[] { " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);
        topic = splitedInput[0];
        course = splitedInput[1];
        contestLink = splitedInput[2];
        problems = SkipThreeTake(splitedInput);
    }

    static string[] SkipThreeTake(string[] splitedInput)
    {
        problems = new string[splitedInput.Length - 3];
        for (int index = 3; index < splitedInput.Length; index++)
        {
            problems[index - 3] = splitedInput[index];
        }
        return problems;
    }

    static void AddToListWithGivenInformation()
    {
        var newExercise = new Exercise();
        newExercise.Topic = topic;
        newExercise.CourceName = course;
        newExercise.JudgeContestLink = contestLink;
        newExercise.Problems = new string[problems.Length];
        newExercise.Problems = problems;
        givenInformation.Add(newExercise);
    }

    static void PrintResultByGivenOrder()
    {
        foreach (var exercise in givenInformation)
        {
            Console.WriteLine($"Exercises: {exercise.Topic}");
            Console.WriteLine(
                $"Problems for exercises and homework for the \"{exercise.CourceName}\" course @ SoftUni.");
            Console.WriteLine($"Check your solutions here: {exercise.JudgeContestLink}");
            var counter = 1;
            foreach (var item in exercise.Problems)
            {
                Console.WriteLine($"{counter}. {item}");
                counter++;
            }
        }
    }
}
