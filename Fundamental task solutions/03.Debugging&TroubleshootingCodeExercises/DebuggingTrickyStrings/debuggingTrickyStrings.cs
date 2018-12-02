using System;
class TrickyStrings
{
    static void Main(string[] args)
    {
        //using System;
        //class TrickyStrings
        //{
        //    static void Main(string[] args)
        //    {
        //        var numberOfStrings = int.Parse(Console.ReadLine());
        //        var delimiter = Console.ReadLine();
        //        var result = string.Empty;
        //        var currentString = string.Empty;
        //        for (int i = 0; i <= numberOfStrings; i++)
        //            currentString += Console.ReadLine();
        //        result += currentString + delimiter;
        //        currentString = Console.ReadLine();
        //        result += currentString;
        //        Console.WriteLine(result);
        //    }
        //}
        string delimiter = Console.ReadLine();
        int numberOfStrings = int.Parse(Console.ReadLine());

        string result = string.Empty;
        string currentString = string.Empty;

        for (int i = 1; i <= numberOfStrings; i++)
        {

            currentString = Console.ReadLine();

            result += currentString;
            if (i == numberOfStrings)
            {
                break;
            }
            result += delimiter;
        }
        Console.WriteLine(result);
    }
}
