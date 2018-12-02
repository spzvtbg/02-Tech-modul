using System;
using System.Linq;
using System.Collections.Generic;
namespace _01.ShootListElements
{
    public class shootThemAll
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string print = string.Empty;
            double theLast = 0;
            List<double> list = new List<double>();

            for (int i = 0; ; i++)
            {
                if (input != "stop" && input != "bang")
                {
                    list.Insert(0, double.Parse(input));
                }
                else if (input == "bang")
                {
                    if (list.Count > 0)
                    {
                        list = ListRebuilding(list);
                        Console.WriteLine($"shot {list[list.Count - 1]}");
                        theLast = list[list.Count - 1];
                        list.Remove(list[list.Count - 1]);
                    }
                    else
                    {
                        Console.WriteLine($"nobody left to shoot! last one was {theLast}");
                        break;
                    }
                }
                else
                {
                    if (list.Count > 0)
                    {
                        Console.WriteLine($"survivors: {string.Join(" ", list)}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"you shot them all. last one was {theLast}");
                        break;
                    }
                }
                input = Console.ReadLine();
            }
        }

        private static List<double> ListRebuilding(List<double> list)
        {
            double average = 0;
            for (int a = 0; a < list.Count; a++)
            {
                average += list[a];
            }
            average /= list.Count;

            for (int b = 0; b < list.Count; b++)
            {
                if (list[b] < average)
                {
                    list.Add(list[b]);
                    list.RemoveAt(b);
                    break;
                }
            }
            for (int c = 0; c < list.Count - 1; c++)
            {
                list[c]--;
                if (list[c] < 1)
                {
                    list.Remove(list[c]);
                    c--;
                }
            }
          
            return list;
        }
    }
}
