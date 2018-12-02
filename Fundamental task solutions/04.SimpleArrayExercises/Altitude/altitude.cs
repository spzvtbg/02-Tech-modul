using System;
using System.Linq;
namespace Altitude
{
    public class altitude
    {
        public static void Main()
        {
            string[] comands = Console.ReadLine().Split(' ').ToArray();

            int ctr = int.Parse(comands[0]);
            double result = ctr;
            double diff = 0;

            for (int i = 1; i < comands.Length - 1; i += 2)
            {
                if(comands[i] == "up")
                {
                    result += double.Parse(comands[i + 1]);
                    diff += double.Parse(comands[i + 1]); 
                }
                if (comands[i] == "down")
                {
                    result -= double.Parse(comands[i + 1]);
                    diff -= double.Parse(comands[i + 1]);
                }
                if (result <= 0)
                {
                    break;
                }
            }
            Console.WriteLine(result > 0 ? $"got through safely. current altitude: {ctr + diff}m" :
                $"crashed");
        }
    }
}
