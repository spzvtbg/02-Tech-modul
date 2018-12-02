using System;

public class WinningTicket
{
    static string[] ticketsCollection;

    static string firstHalfFromTicket;
    static string firstHalfSymbol;
    static byte counterFirstHalf;

    static string lastHalfFromTicket;
    static string lastHalfSymbol;
    static byte counterLastHalf;

    public static void Main()
    {
        ticketsCollection = Console.ReadLine().Split(new[] {  " ", ", " }, 
            StringSplitOptions.RemoveEmptyEntries);

        CheckAllTickets();
        PrintAllWins();
    }

    static void PrintAllWins()
    {
        foreach (var ticket in ticketsCollection)
        {
            Console.WriteLine(ticket);
        }
    }

    static void CheckAllTickets()
    {
        for (int index = 0; index < ticketsCollection.Length; index++)
        {
            if (ticketsCollection[index].Length < 20 || ticketsCollection[index].Length > 20)
            {
                ticketsCollection[index] = "invalid ticket";
            }
            else
            {
                ticketsCollection[index] = $"ticket \"{ticketsCollection[index]}\" - {DivideAndRule(index)}";
            }
        }
    }

    static string DivideAndRule(int index)
    {
        firstHalfFromTicket = ticketsCollection[index].Substring(0, 10);
        var returned = CheckMostOccurenceSymbol(firstHalfFromTicket);
        firstHalfSymbol = returned[0];
        counterFirstHalf = Convert.ToByte(returned[1]);

        lastHalfFromTicket = ticketsCollection[index].Substring(10, 10);
        returned = CheckMostOccurenceSymbol(lastHalfFromTicket);
        lastHalfSymbol = returned[0];
        counterLastHalf = Convert.ToByte(returned[1]);

        return TakeResult();
    }

    static string[] CheckMostOccurenceSymbol(string halfFromTicket)
    {
        var counter = 1;
        var symbol = halfFromTicket[0];
        for (int index = 1; index < halfFromTicket.Length; index++)
        {
            if (symbol != halfFromTicket[index] && index < 5)
            {
                counter = 1;
                symbol = halfFromTicket[index];
            }
            else if (symbol == halfFromTicket[index])
            {
                counter++;
            }
            else if (symbol != halfFromTicket[index] && index >= 5)
            {
                return new[] { symbol.ToString(), counter.ToString() };
            }
        }
        return new[] { symbol.ToString(), counter.ToString() };
    }

    static string TakeResult()
    {
        if (isWinSymbol() && isEqual())
        {
            if (counterLastHalf == 10 && counterFirstHalf == 10)
            {
                return $"{counterFirstHalf}{firstHalfSymbol} Jackpot!";
            }
            else return $"{Math.Min(counterFirstHalf, counterLastHalf)}{firstHalfSymbol}";
        }
        else return "no match";
    }

    private static bool isWinSymbol()
    {
        return firstHalfSymbol == "@" || firstHalfSymbol == "#" || firstHalfSymbol == "$" || firstHalfSymbol == "^";
    }

    private static bool isEqual()
    {
        return firstHalfSymbol == lastHalfSymbol && counterFirstHalf >= 6 && counterLastHalf >= 6;
    }
}
