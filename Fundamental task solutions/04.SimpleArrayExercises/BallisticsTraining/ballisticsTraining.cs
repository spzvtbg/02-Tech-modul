using System;
using System.Linq;
namespace BallisticsTraining
{
    public class ballisticsTraining
    {
        public static void Main()
        {
            string[] cordinates = Console.ReadLine().Split(' ').ToArray();
            string[] comands = Console.ReadLine().Split(' ').ToArray();

            int X = int.Parse(cordinates[0]);
            int Y = int.Parse(cordinates[1]);

            int x = 0;
            int y = 0;

            for (int i = 0; i < comands.Length - 1; i += 2)
            {
                if (comands[i] == "up")      //  Y
                {
                    y = int.Parse(comands[i + 1]) >= 0 ? y += int.Parse(comands[i + 1]) : 
                        y -= Math.Abs(int.Parse(comands[i + 1]));
                }                              
                if (comands[i] == "down")    //  Y
                {
                    y = int.Parse(comands[i + 1]) >= 0 ? y -= int.Parse(comands[i + 1]) : 
                        y += Math.Abs(int.Parse(comands[i + 1]));
                }                              
                if (comands[i] == "left")    //  X
                {
                    x = int.Parse(comands[i + 1]) >= 0 ? x -= int.Parse(comands[i + 1]) : 
                        x += Math.Abs(int.Parse(comands[i + 1]));
                }                              
                if (comands[i] == "right")   //  X
                {
                    x = int.Parse(comands[i + 1]) >= 0 ? x += int.Parse(comands[i + 1]) : 
                        x -= Math.Abs(int.Parse(comands[i + 1]));
                }
            }
            Console.WriteLine(x == X && y == Y? $"firing at [{x}, {y}]\ngot 'em!" : 
                $"firing at [{x}, {y}]\nbetter luck next time...");
        }
    }
}