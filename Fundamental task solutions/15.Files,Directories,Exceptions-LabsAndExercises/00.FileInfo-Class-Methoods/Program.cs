namespace _00.FileInfo_Class_Methoods
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            //File.Create("../../DemoFileInfo.txt");

            //File.WriteAllText("../../DemoFileInfo.txt", "FileInfo - excersises...");

            FileInfo file = new FileInfo("../../DemoFileInfo.txt");

            Console.WriteLine("0. File name: {0}", file.Name);
            Console.WriteLine();

            Console.WriteLine("1. File lenght: {0} symbols.", file.Length);
            Console.WriteLine();

            Console.WriteLine("2. File type: {0}", file.GetType());
            Console.WriteLine();

            Console.WriteLine("3. File isReadOnly: {0}", file.IsReadOnly);
            Console.WriteLine();

            Console.WriteLine("4. File last acces time: {0}", file.LastAccessTime);
            Console.WriteLine();

            File.AppendAllText("../../DemoFileInfo.txt", " 1, 2, 3");

            Console.WriteLine("5. File last write time: {0}", file.LastWriteTime);
            Console.WriteLine();

            Console.WriteLine("6.File hash code: {0}", file.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("7. File directory name: {0}", file.DirectoryName);
            Console.WriteLine();
        }
    }
}
