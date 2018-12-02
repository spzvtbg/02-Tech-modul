using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Batteries
{
    class batteries
    {
        static void Main()
        {
            List<double> capacity = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> expenseProHour = Console.ReadLine().Split().Select(double.Parse).ToList();
            int testHours = int.Parse(Console.ReadLine());

            int counter = 1;
            double endBalance = 0;
            double endPercent = 0;
            double deadHours = 0;
            string result = string.Empty;

            for (int i = 0; i < capacity.Count; i++)
            {
                endBalance = Math.Round(capacity[i] - expenseProHour[i] * testHours, 2);
                endPercent = Math.Round(endBalance / capacity[i] * 100, 2);
                deadHours = Math.Ceiling(capacity[i] / expenseProHour[i]);
                if (endBalance > 0)
                {
                    result = $"Battery {counter}: {endBalance:0.00} mAh ({endPercent:0.00})%";
                }
                else
                {
                    result = $"Battery {counter}: dead (lasted {deadHours} hours)";
                }
                Console.WriteLine(result);
                counter++;
            }
        }
    }
}
