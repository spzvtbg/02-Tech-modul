using System;
using System.Collections.Generic;
using System.Linq;

public class lotto
{
    public static void Main()
    {
        var counter = 0;
        var list = new List<int> { 3, 4, 13, 15, 16, 17, 20, 29, 33, 35, 38, 43, 44, 45, 46 };
        for (int a = 0; a < list.Count; a++)
        {
            for (int b = 0; b < list.Count; b++)
            {
                for (int c = 0; c < list.Count; c++)
                {
                    for (int d = 0; d < list.Count; d++)
                    {
                        for (int e = 0; e < list.Count; e++)
                        {
                            for (int f = 0; f < list.Count; f++)
                            {
                                if (list[a] >= list[b] || list[a] == list[c] || list[a] == list[d] || list[a] == list[e] || list[a] == list[f] ||
                                    list[b] >= list[c] || list[b] == list[d] || list[b] == list[e] || list[b] == list[f] ||
                                    list[c] >= list[d] || list[c] == list[e] || list[c] == list[f] ||
                                    list[d] >= list[e] || list[d] == list[f] ||
                                    list[e] >= list[f]) { continue; }
                                else
                                {
                                    counter++;
                                    Console.WriteLine($"{list[a]}---{list[b]}---{list[c]}---{list[d]}---{list[e]}---{list[f]} ===> {counter}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}