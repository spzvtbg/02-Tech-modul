namespace _04.WinningTicket
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;

    public class WinningTicket
    {
        public static void Main()
        {
            var tickets = Console.ReadLine().Split(',').ToList();

            var ticketsDictionary = new Dictionary<string, string>();

            foreach (var ticket in tickets)
            {
                var currentticket =  ticket.Trim();

                if (currentticket.Length < 20 || currentticket.Length > 20)
                {
                    ticketsDictionary[currentticket] = "invalid ticket";

                    continue;
                }

                var leftHalf = string.Empty;

                var rightHalf = string.Empty;

                for (int charIndex = 0; charIndex < currentticket.Length; charIndex++)
                {
                    if (charIndex < 10) { leftHalf += currentticket[charIndex]; }

                    else { rightHalf += currentticket[charIndex]; }
                }

                var win = new Regex(@"(\^{5,})|(\#{5,})|(\${5,})|(\@{5,})");

                var currentWinLeft = win.Match(leftHalf);

                var currentWinRight = win.Match(rightHalf);

                var currentWin = currentWinLeft.Value.Length <= currentWinRight.Value.Length ?

                    currentWinLeft.Value : currentWinRight.Value;

                if (win.IsMatch(leftHalf) && win.IsMatch(rightHalf) &&  currentWin.Length < 10)
                {
                    ticketsDictionary[currentticket] = $"ticket \"{currentticket}\" - {currentWin.Length}{currentticket[4]}";
                }
                if (win.IsMatch(leftHalf) && win.IsMatch(rightHalf) && currentWin.Length == 10)
                {
                    ticketsDictionary[currentticket] = $"ticket \"{currentticket}\" - {currentWin.Length}{currentticket[0]} Jackpot!";
                }
                if (!win.IsMatch(leftHalf) || !win.IsMatch(rightHalf))
                {
                    ticketsDictionary[currentticket] = $"ticket \"{currentticket}\" - no match";
                }
            }

            foreach (var ticket in ticketsDictionary)
            {
                Console.WriteLine(ticket.Value);
            }
        }
    }
}
