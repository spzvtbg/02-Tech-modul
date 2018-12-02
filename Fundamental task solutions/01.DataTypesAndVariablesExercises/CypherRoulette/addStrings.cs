using System;
namespace CypherRoulette
{
    public class addStrings
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            string endStr = "";
            string tempStr = "";
            string nowStr = "";

            for (int a = 0; a < n; a++)
            {
                string nextStr = Console.ReadLine();
                nowStr = nextStr;

                if (nextStr == "spin")
                {
                    counter++;
                    nowStr = "";
                    a--;
                }
                if (tempStr == nextStr)
                {
                    endStr = "";
                    nowStr = "";
                    if (nextStr == "spin")
                    {
                        counter++;
                    }
                }
                if (counter % 2 != 0)
                {
                    endStr = nowStr + endStr;
                }
                else
                {
                    endStr = endStr + nowStr;
                }

                tempStr = nextStr;
            }
            Console.WriteLine(endStr);
        }
    }
}
