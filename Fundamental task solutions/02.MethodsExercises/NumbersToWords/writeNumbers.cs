using System;
namespace MyTechModule2
{
    public class Program
    {
        public static void Main()
        {
            int loopLenght = int.Parse(Console.ReadLine());

            for (int i = 1; i <= loopLenght; i++)
            {
                string toText = string.Empty;

                int number = int.Parse(Console.ReadLine());

                if (number < -999)
                {
                    toText = "too small";
                }
                else if (number > 999)
                {
                    toText = "too large";
                }
                else
                {
                    if (number <= -100)
                    {
                        toText = "minus " + ConvertDigits(number);
                    }
                    else if (number >= 100)
                    {
                        toText = ConvertDigits(number);
                    }
                }
                Console.WriteLine(toText);
            }
        }

        private static string ConvertDigits(int n)
        {

            string[,] digis = {  { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", },

                { "", "ten ", "twenty ", "thirty ", "forty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninety " },

                { "", "one-hundred ", "two-hundred ", "three-hundred ", "four-hundred ",
                    "five-hundred ", "six-hundred ", "seven-hundred ", "eight-hundred ", "nine-hundred " },

            { "", "eleven ", "twelve ", "thirteen ", "fourteen ", "fifteen ",
                    "sixteen ", "seventeen ", "eighteen ", "nineteen "} };

            int num = Math.Abs(n);
            int tempNum = 0;
            string text = string.Empty;

            if (num % 100 == 0)
            {
                tempNum = num / 100;
                text = digis[2, tempNum];
            }
            else if (num > 100 && num / 100 != 0 && num % 100 > 10 && num % 100 < 20)
            {
                tempNum = num % 10;
                text = digis[3, tempNum] + text;
                num /= 100;
                text = digis[2, num] + "and " + text;
            }
            else if (num > 100 && num / 100 != 0)
            {
                tempNum = num % 10;
                text = digis[0, tempNum] + text;
                num /= 10;
                tempNum = num % 10;
                text = digis[1, tempNum] + text;
                num /= 10;
                tempNum = num % 10;
                text = digis[2, tempNum] + "and " + text;
            }
            return text;
        }
    }
}