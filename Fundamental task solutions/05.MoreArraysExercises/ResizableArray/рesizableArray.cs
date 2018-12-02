using System;
using System.Linq;
using System.Text;
namespace ResizableArray
{
    public class рesizableArray
    {
        public static void Main()
        {
            string[] command = Console.ReadLine().Split(' ').ToArray();

            string[] nowArray = { };

            while (command[0] != "end")
            {
                nowArray = command[0] == "push" ? AddToArray(nowArray, command[1]) :
                    command[0] == "pop" ? RemoveTheLastElement(nowArray) :
                    command[0] == "removeAt" ? RemoveAtIndex(nowArray, command[1]) :
                    new string[0];

                command = Console.ReadLine().Split(' ').ToArray();
            }

            string result = nowArray.Length > 0 ? result = ConvertToString(nowArray) : "empty array";

            Console.WriteLine(result);
             
        }

        private static string ConvertToString(string[] nowArray)
        {
            string result = string.Empty;
            for (int i = 0; i < nowArray.Length; i++)
            {
                result = result + nowArray[i] + " ";
            }
            return result;
        }

        private static string[] RemoveAtIndex(string[] nowArray, string index)
        {
            int n = int.Parse(index);
            nowArray = nowArray.Length - 1 >= n ? RemoveIndex(nowArray, n) : nowArray;
            return nowArray;
        }

        private static string[] RemoveIndex(string[] nowArray, int n)
        {
            int a = 0;
            string[] tempArray = new string[nowArray.Length - 1];
            for (int i = 0; i < nowArray.Length; i++)
            {
                if (i == n)
                {
                    continue;
                }
                else
                {
                    tempArray[a] = nowArray[i];
                    a++;
                }
            }
            return tempArray;
        }

        private static string[] RemoveTheLastElement(string[] nowArray)
        {
            string[] newArray = nowArray.Length > 0 ? new string[nowArray.Length - 1] : new string[0];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = nowArray[i];
            }

            return newArray;
        }

        private static string[] AddToArray(string[] nowArray, string element)
        {

            string[] newArray = new string[nowArray.Length + 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = i < nowArray.Length ? nowArray[i] : element;
            }

            return newArray;
        }
    }
}
