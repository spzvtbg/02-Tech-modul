namespace _04.CottageScraper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CottageScraper
    {
        public static void Main()
        {
            var CottageScraper = new Dictionary<string, List<int>>();
            var material = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            var count = 0;
            while (material[0] != "chop")
            {
                count++;
                if (!CottageScraper.ContainsKey(material[0]))
                {
                    CottageScraper[material[0]] = new List<int>();
                }
                CottageScraper[material[0]].Add(int.Parse(material[1]));

                material = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            var treeKind = Console.ReadLine();
            var treeLenght = int.Parse(Console.ReadLine());
           
            var priceLM = Math.Round(CottageScraper.Values.Sum(d => d.Sum()) / (double)count, 2);
            Console.WriteLine($"Price per meter: ${priceLM:0.00}");
          
            var used = Math.Round(CottageScraper[treeKind].Where(x => x >= treeLenght).Sum() * priceLM, 2);
            Console.WriteLine($"Used logs price: ${used:0.00}");
        
            var unused = Math.Round((CottageScraper[treeKind].Where(x => x < treeLenght).Sum() + 
                CottageScraper.Values.Sum(x => x.Sum()) - CottageScraper[treeKind].Sum()) * priceLM * 0.25, 2);
            Console.WriteLine($"Unused logs price: ${unused:0.00}");
       
            Console.WriteLine($"CottageScraper subtotal: ${(used + unused):0.00}");
        }
    }
}
