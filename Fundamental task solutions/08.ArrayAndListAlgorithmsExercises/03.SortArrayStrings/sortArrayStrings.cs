using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SortArrayStrings
{
    class sortArrayStrings
    {
        static void Main()
        {
            List<string> inputLine = Console.ReadLine().Split(' ').ToList();
            
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 1; i < inputLine.Count; i++)
                {
                    string temp = string.Empty;
                    int x = string.Compare(inputLine[i - 1], inputLine[i]);
                    if (x > 0)
                    {
                        temp = inputLine[i];
                        inputLine[i] = inputLine[i - 1];
                        inputLine[i - 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            Console.WriteLine(string.Join(" ", inputLine));
        }
    }
}

