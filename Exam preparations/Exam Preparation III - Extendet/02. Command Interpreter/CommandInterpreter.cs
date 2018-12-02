using System;

public class CommandInterpreter
{
    static string action;
    static int index;
    static int count;

    static string[] workCollection;

    public static void Main()
    {
        workCollection = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        ReadComandsUntilEndFrom(Console.ReadLine());
        PrintResult();
    }

    static void PrintResult()
    {
        var isFirst = true;
        Console.Write("[");
        foreach (var item in workCollection)
        {
            if (isFirst)
            {
                Console.Write(item);
                isFirst = false;
                continue;
            }
            Console.Write(", {0}", item);
        }
        Console.WriteLine("]");
    }

    static void ReadComandsUntilEndFrom(string comand)
    {
        if (comand != "end")
        {
            DivideAndRule(comand);
            ReadComandsUntilEndFrom(Console.ReadLine());
        }
        else return;
    }

    static void DivideAndRule(string comand)
    {
        var splited = comand.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        action = splited[0];
        if (action == "reverse")
        {
            ReverseFrom(splited);
        }
        else if (action == "sort")
        {
            SortFrom(splited);
        }
        else if (action == "rollLeft")
        {
            RollLeft(splited);
        }
        else if (action == "rollRight")
        {
            RollRight(splited);
        }
    }

    static bool IsValidComand()
    {
        return index >= 0 &&
            count >= 0 &&
            index <= workCollection.Length - 1 && 
            index + count - 1 <= workCollection.Length - 1;
    }

    static void ReverseFrom(string[] splited)
    {
        index = Convert.ToInt32(splited[2]);
        count = Convert.ToInt32(splited[4]);
        if (IsValidComand())
        {
            for (int i = 0; i < count / 2; i++)
            {
                var first = index + i;
                var last = index + count - 1 - i;
                var temporary = workCollection[first];
                workCollection[first] = workCollection[last];
                workCollection[last] = temporary;
            }
        }
        else Console.WriteLine("Invalid input parameters."); return;
    }

    static void SortFrom(string[] splited)
    {
        index = Convert.ToInt32(splited[2]);
        count = Convert.ToInt32(splited[4]);
        if (IsValidComand())
        {
            while (true)
            {
                var isSwapped = false;
                for (int i = 0; i < count - 1; i++)
                {
                    if (workCollection[index + i].CompareTo(workCollection[index + i + 1]) == 1)
                    {
                        var temporary = workCollection[index + i];
                        workCollection[index + i] = workCollection[index + i + 1];
                        workCollection[index + i + 1] = temporary;
                        isSwapped = true;
                    }
                }
                if (!isSwapped) { return; }
            }
        }
        else Console.WriteLine("Invalid input parameters."); return;
    }


    static void RollLeft(string[] splited)
    {
        count = Convert.ToInt32(splited[1]);
        if (count < 0)
        {
            Console.WriteLine("Invalid input parameters."); return;
        }

        var length = count % workCollection.Length;
        for (int index = 1; index <= length; index++)
        {
            var temporary = workCollection[0];
            for (int i = 0; i < workCollection.Length - 1; i++)
            {
                workCollection[i] = workCollection[i + 1];
            }
            workCollection[workCollection.Length - 1] = temporary;
        }
    }

    static void RollRight(string[] splited)
    {
        count = Convert.ToInt32(splited[1]);
        if (count < 0)
        {
            Console.WriteLine("Invalid input parameters."); return;
        }

        var length = count % workCollection.Length;
        for (int index = 1; index <= length; index++)
        {
            var temporary = workCollection[workCollection.Length - 1];
            for (int i = workCollection.Length - 1; i > 0; i--)
            {
                workCollection[i] = workCollection[i - 1];
            }
            workCollection[0] = temporary;
        }
    }
}
