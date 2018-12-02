namespace _02.OptimizedBankingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BankAkount
    {
        public string Name { get; set; }

        public string Bank { get; set; }

        public decimal Balance { get; set; }

        public static BankAkount Parse(string entered)
        {
            var teil = entered.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
            return new BankAkount
            {
                Name = teil[1],
                Bank = teil[0],
                Balance = decimal.Parse(teil[2])
            };
        }
           
    }


    public class OptimizedBankingSystem
    {
        public static void Main()
        {
            var nameBalanceBank = new Dictionary<string, Dictionary<string, decimal>>();

            var enteredDaten = Console.ReadLine();

            while (enteredDaten != "end")
            {
                var currentDaten = BankAkount.Parse(enteredDaten);

                if (!nameBalanceBank.ContainsKey(currentDaten.Name))
                {
                    nameBalanceBank[currentDaten.Name] = new Dictionary<string, decimal>();
                }
                if (!nameBalanceBank[currentDaten.Name].ContainsKey(currentDaten.Bank))
                {
                    nameBalanceBank[currentDaten.Name][currentDaten.Bank] = 0;
                }
                nameBalanceBank[currentDaten.Name][currentDaten.Bank] += currentDaten.Balance;
               

                enteredDaten = Console.ReadLine();
            }

            foreach (var item in nameBalanceBank.OrderByDescending(b => b.Value.Max(m => m.Value)))
            {
                foreach (var kvp in item.Value.OrderBy(k => k.Key))
                {
                    Console.WriteLine($"{item.Key} -> {kvp.Value} ({kvp.Key})");
                }
            }
        }
    }
}
