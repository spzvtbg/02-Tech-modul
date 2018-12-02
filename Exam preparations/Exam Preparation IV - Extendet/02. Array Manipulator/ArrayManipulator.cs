using System;
using System.Linq;

public class ArrayManipulator
{
    static int[] workArray;

    static string[] splited;

    static string command;
    static int argument;

    static int index;
    static int count;

    public static void Main()
    {
        workArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var currentInput = Console.ReadLine();
        while (currentInput != "end")
        {
            splited = currentInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            command = splited[0];

            if (command == "exchange")
            {
                index = Convert.ToInt32(splited[1]);
                if (index < 0 || index >= workArray.Length)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    var workList1 = workArray.Take(index + 1).ToList();
                    var workList2 = workArray.Skip(index + 1).ToList();
                    workList2.AddRange(workList1);
                    workArray = workList2.ToArray();
                }
            }
            if (command == "max")
            {
                int max;
                argument = splited[1] == "odd" ? 1 : 0;
                try
                {
                    max = workArray.Where(x => x % 2 == argument).Max();
                    var outIndex = workArray.ToList().LastIndexOf(max);
                    Console.WriteLine(outIndex);
                }
                catch (Exception)
                {
                    Console.WriteLine("No matches");
                }
            }
            if (command == "min")
            {
                int min;
                argument = splited[1] == "odd" ? 1 : 0;
                try
                {
                    min = workArray.Where(x => x % 2 == argument).Min();
                    var outIndex = workArray.ToList().LastIndexOf(min);
                    Console.WriteLine(outIndex);
                }
                catch (Exception)
                {
                    Console.WriteLine("No matches");
                }
            }
            if (command == "first")
            {
                count = Convert.ToInt32(splited[1]);
                argument = splited[2] == "odd" ? 1 : 0;

                if (count > workArray.Length || count < 1)
                {
                    Console.WriteLine("Invalid count");
                }
                else if (workArray.Where(x => x % 2 == argument).ToArray().Length > 0)
                {
                    Console.WriteLine($"[{string.Join(", ", workArray.Where(x => x % 2 == argument).Take(count))}]");
                }
                else
                {
                    Console.WriteLine($"[]");
                }
            }
            if (command == "last")
            {
                count = Convert.ToInt32(splited[1]);
                argument = splited[2] == "odd" ? 1 : 0;

                if (count > workArray.Length || count < 1)
                {
                    Console.WriteLine("Invalid count");
                }
                else if (workArray.Where(x => x % 2 == argument).ToArray().Length > 0)
                {
                    Console.WriteLine($"[{string.Join(", ", workArray.Where(x => x % 2 == argument).Reverse().Take(count).Reverse())}]");
                }
                else
                {
                    Console.WriteLine($"[]");
                }
            }

            currentInput = Console.ReadLine();
        }
        Console.WriteLine($"[{string.Join(", ", workArray)}]");
    }
}