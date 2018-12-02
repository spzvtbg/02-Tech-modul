using System;
using System.Linq;
namespace Phonebook
{
    public class phonebook
    {
        public static void Main()
        {
            string[] telNumbers = Console.ReadLine().Split(' ').ToArray();
            string[] names = Console.ReadLine().Split(' ').ToArray();

            string search = Console.ReadLine();

            while (search != "done")
            {
                SearchData(telNumbers, names, search);
                search = Console.ReadLine();
            }
        }

        private static void SearchData(string[] telNumbers, string[] names, string search)
        {
            string str = string.Empty;
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write(search == names[i] ? $"{names[i]} -> {telNumbers[i]}" : "");
            }
            Console.WriteLine();
        }
    }
}
