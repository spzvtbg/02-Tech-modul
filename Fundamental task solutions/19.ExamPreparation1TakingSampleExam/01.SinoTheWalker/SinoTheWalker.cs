namespace _01.SinoTheWalker
{
    using System;
    using System.Globalization;
   
    public class SinoTheWalker
    {
        public static void Main()
        {
            var leavesTime = DateTime.ParseExact(Console.ReadLine(),"HH:mm:ss", CultureInfo.InvariantCulture);

            var steps = long.Parse(Console.ReadLine());

            var secondsPerStep = long.Parse(Console.ReadLine());

            var totalSeconds = steps * secondsPerStep % (24 * 60 * 60);

            var addSeconds = 0L;

            if (totalSeconds > 0)
            {
                addSeconds = totalSeconds;
            }
            else
            {
                addSeconds = steps * secondsPerStep;
            }

            var arrivalTime = leavesTime.AddSeconds(addSeconds);

            Console.WriteLine("Time Arrival: " + arrivalTime.ToString("HH:mm:ss"));
        }
    }
}
