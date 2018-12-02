using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DecodeRadioFrequencies
{
    class decodeRadioFrequencies
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split().ToList();

            List<int> outputChars = new List<int>();
            List<int> inputNumbers = new List<int>();
            List<int> temp = new List<int>();

            ExtractTheInts(input, inputNumbers);
            RemoveZero(inputNumbers);
            ReSort(outputChars, inputNumbers, temp);

            for (int i = 0; i < outputChars.Count; i++)
            {
                Console.Write((char)outputChars[i]);
            }
            Console.WriteLine();
        }

        private static void ReSort(List<int> outputChars, List<int> inputNumbers, List<int> temp)
        {
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    outputChars.Add(inputNumbers[i]);
                }
            }
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                if (i % 2 != 0)
                {
                    temp.Add(inputNumbers[i]);
                }
            }
            temp.Reverse();
            for (int i = 0; i < temp.Count; i++)
            {
                outputChars.Add(temp[i]);
            }
        }

        private static void RemoveZero(List<int> inputNumbers)
        {
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                if (inputNumbers[i] == 0)
                {
                    inputNumbers.Remove(inputNumbers[i]);
                    i--;
                }
            }
        }

        private static void ExtractTheInts(List<string> input, List<int> inputNumbers)
        {
            for (int i = 0; i < input.Count; i++)
            {
                string numbers = string.Empty;
                for (int j = 0; j < input[i].Length; j++)
                {
                    if ((input[i])[j] != '.')
                    {
                        numbers += (input[i])[j];
                    }
                    else
                    {
                        inputNumbers.Add(int.Parse(numbers));
                        numbers = string.Empty;
                    }
                }
                inputNumbers.Add(int.Parse(numbers));
            }
        }
    }
}
