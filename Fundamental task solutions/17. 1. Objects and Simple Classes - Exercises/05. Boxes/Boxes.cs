using System;
using System.Collections.Generic;
using System.Linq;

public class Box
{
    public int X1 { get; set; }
    public int X2 { get; set; }
    public int Y1 { get; set; }
    public int Y2 { get; set; }

    public static int Height(int Y1, int Y2)
    {
        var height = Math.Abs(Y1 - Y2);
        return height;
    }

    public static int Widht(int X1, int X2)
    {
        var widht = Math.Abs(X1 - X2);
        return widht;
    }
}

public class Boxes
{
    static string[] p1;
    static string[] p2;
    static string[] p3;

    static List<Box> boxes = new List<Box>();

    public static void Main()
    {
        ReadSeveralCordinatesFrom(Console.ReadLine());
        PrintAllBoxes();
    }

    static void PrintAllBoxes()
    {
        foreach (var box in boxes)
        {
            var widht = Box.Widht(box.X1, box.X2);
            var height = Box.Height(box.Y1, box.Y2);

            Console.WriteLine($"Box: {widht}, {height}");
            Console.WriteLine($"Perimeter: {(widht + height) * 2}");
            Console.WriteLine($"Area: {widht * height}");
        }
    }

    static void SplitCurrent(string input)
    {
        var cordinates = input.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        p1 = new string[2];
        p1 = cordinates[0].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        p2 = new string[2];
        p2 = cordinates[1].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        p3 = new string[2];
        p3 = cordinates[2].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
    }

    static void ReadSeveralCordinatesFrom(string input)
    {
        if (input != "end")
        {
            SplitCurrent(input);
            AddNewBox();
            ReadSeveralCordinatesFrom(Console.ReadLine());
        }
        else return;
    }

    static void AddNewBox()
    {
        var box = new Box();
        box.X1 = Convert.ToInt32(p1[0]);
        box.X2 = Convert.ToInt32(p2[0]);
        box.Y1 = Convert.ToInt32(p2[1]);
        box.Y2 = Convert.ToInt32(p3[1]);
        boxes.Add(box);
    }
}
