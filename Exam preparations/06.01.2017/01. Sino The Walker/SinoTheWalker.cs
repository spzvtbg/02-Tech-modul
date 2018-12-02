using System;

public class SinoTheWalker
{
    public static void Main()
    {
        var timeToLeavesSoftUni = Console.ReadLine()
            .Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
        var stepsToHome = Convert.ToUInt64(Console.ReadLine());
        var timeForEachStepInSeconds = Convert.ToUInt64(Console.ReadLine());

        var totalTimeInSeconds =
            Convert.ToUInt64(timeToLeavesSoftUni[2]) +
            Convert.ToUInt64(timeToLeavesSoftUni[1]) * 60 +
            Convert.ToUInt64(timeToLeavesSoftUni[0]) * 60 * 60 + 
            stepsToHome * timeForEachStepInSeconds;

        var secondsInOneDay = 24 * 60 * 60;
        var leftTimeToConverting = totalTimeInSeconds % (ulong)secondsInOneDay;

        var totalHours = leftTimeToConverting / (60 * 60);
        var totalMinutes = (leftTimeToConverting % (60 * 60)) / 60;
        var totalSeconds = (leftTimeToConverting % (60 * 60)) % 60;

        Console.WriteLine("Time Arrival: {0:00}:{1:00}:{2:00}", totalHours, totalMinutes, totalSeconds);
    }
}
