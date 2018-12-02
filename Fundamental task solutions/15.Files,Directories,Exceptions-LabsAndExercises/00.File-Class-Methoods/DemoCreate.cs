namespace MyTemplate1
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        ////---( ReadAllText )---
        //public static void Main()
        //{
        //    string file = File.ReadAllText("../../DemoReadAllText.txt");
        //    Console.WriteLine(file);
        //}

        ////---( ReadAllLines )---
        //public static void Main()
        //{
        //    string[] file = File.ReadAllLines("../../DemoReadAllLines.txt");
        //    Console.WriteLine(string.Join(" ", file));
        //}

        ////---( WriteAllText )---
        //public static void Main()
        //{
        //    File.WriteAllText("../../DemoWriteAllText.txt", " 12345...");
        //    //- WriteAllText create new file,when use a exiastig file reWrite the file all times.
        //    string file = File.ReadAllText("../../DemoWriteAllText.txt");
        //    Console.WriteLine(file);

        //    File.WriteAllText("../../DemoWriteAllText.txt", " 9,10");
        //    string fileReWrite = File.ReadAllText("../../DemoWriteAllText.txt");
        //    Console.WriteLine(fileReWrite);
        //}

        ////---( WriteAllLines )---
        //public static void Main()
        //{
        //    File.WriteAllText("../../DemoWriteAllLines.txt", "1.WriteAllLines methood exercises...");

        //    string fileContent = File.ReadAllText("../../DemoWriteAllLines.txt");

        //    List<string> file = fileContent.Split(' ').ToList();

        //    Console.WriteLine(string.Join("\r\n", file));
        //}

        ////---( AppendAllText )---
        //public static void Main()
        //{
        //    File.WriteAllText("../../DemoAppendAllText.txt", "1.AppendAllText methood exercises...");

        //    string fileContent = File.ReadAllText("../../DemoWriteAllLines.txt");

        //    List<string> file = fileContent.Split(' ').ToList();

        //    Console.WriteLine(string.Join("\r\n", file));
        //    Console.WriteLine();

        //    File.AppendAllLines("../../DemoAppendAllText.txt", file);
        //    File.AppendAllLines("../../DemoAppendAllText.txt", file);

        //    fileContent = File.ReadAllText("../../DemoAppendAllText.txt");

        //    file = fileContent.Split(' ').ToList();

        //    Console.WriteLine(string.Join("\r\n", file));
        //}
        //---( Create )---
        public static void Main()
        {
            //File.Create("../../DemoCreate.txt");

            //File.Create("../../DemoCreate.html");

            //File.Create("../../DemoCreate.cs");

            string[] program = File.ReadAllLines("../../Program.cs");

            File.WriteAllLines("../../DemoCreate.cs", program);

            string[] fileContent = File.ReadAllLines("../../DemoCreate.cs");

            Console.WriteLine(string.Join("\r\n", fileContent));
        }
    }
}
