namespace _02.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter
    {
        public static void Main()
        {
            var workCollection = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var currentCollection = workCollection;

            var resultCollection = new List<string>();

            while (true)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "reverse")
                {
                    var start = int.Parse(command[2]);

                    var end = int.Parse(command[4]);

                    if (start >= 0 && start < workCollection.Count && end >= 0 &&
                        
                        start + end <= workCollection.Count)
                    {
                        workCollection.Reverse(start, end);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }

                if (command[0] == "sort")
                {
                    var start = int.Parse(command[2]);

                    var end = int.Parse(command[4]);

                    if (start >= 0 && start < workCollection.Count && end >= 0 &&

                        start + end <= workCollection.Count)
                    {
                        workCollection.Sort(start, end, null);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }

                if (command[0] == "rollLeft")
                {
                    var count = int.Parse(command[1]);

                    if (count >= 0)
                    { 
                        var index = count % workCollection.Count;

                        var tempCollection = workCollection.Take(index).ToList();

                        workCollection.RemoveRange(0, index);

                        workCollection.AddRange(tempCollection);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }

                if (command[0] == "rollRight")
                {
                    var count = int.Parse(command[1]);

                    if (count >= 0)
                    {
                        var index = workCollection.Count - count % workCollection.Count;

                        var tempCollection = workCollection.Take(index).ToList();

                        workCollection.RemoveRange(0, index);

                        workCollection.AddRange(tempCollection);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }

                if (command[0] == "end") { break; }
            }

            Console.WriteLine($"[{string.Join(", ", workCollection)}]");
        }
    }
}