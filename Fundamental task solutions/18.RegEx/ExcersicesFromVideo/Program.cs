namespace ExcersicesFromVideo
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            /* -----------------------------------------------------------------------------------------------
             (1). . - точката мачва всеки един символ по отделно, ако търсим точка я ескеипваме с \. 
             (2). [abc] - квадратните скоби мачват или а или б или с 
             (3). [^abc] - с човка мачва всичко освен а б или с 
             (4). [0-9] - мачва цифри
             (5). \w - мачва всички (a - z, A - Z, 0 - 9, _ )
             (6). \W - мачва всичко останало, всякъкви други знаци
             (7). \s - мачва спеисовете и табулация
             (8). \S - мачва всичко което не е спеис или табулация
             (9). \d - всички цифри
            (10). \D - наобратно!
            (11). * - мачва следващият тип елементи 0 или много пъти
            (12). + - мачва следващия елемент 1 или много пъти
            (13). ? - търси 0 или 1 пъти и помага да не търсим "алчно" или грииди
            (14). {6, 12} - търси символи от 6 до 12 символа
            (15). {6} - търси всичко с точно 6 символа включително
            (16). {6,} - търси минимум 6 символа включително
            (17). ^ - започни да търсиш задължително със следващия символ
            (18). $ - търсенето приключва със предходния символ
            (19). | - оператор за или 
            (20). () - скобите групират определена част от търсенето
            (21). ?: - не групира групата в която се намира
            (22). \1 - взема стоиноста от първата група
            ------------------------------------------------------------------------------------------------- */

            /* (01) */

            var regex = new Regex("(\\d{4})-(\\d{2})-(\\d{2})");

            var text = "Today is 2017-04-04";

            var isMatch = regex.IsMatch(text);

            Console.WriteLine("(01). " + isMatch + " -> bool value"/*bool value*/);

            Console.WriteLine();

            /* (02) */

            var match = regex.Match(text);

            Console.WriteLine("(02). " + match.Value);

            Console.WriteLine();

            /* (03) */

            Console.WriteLine("(03.1). " + match.Groups[0] + " -> match all text");

            Console.WriteLine();

            Console.WriteLine("(03.2). " + match.Groups[1] + " -> match first grope...");

            Console.WriteLine();

            /* (04) */

            var anotherText = "Today is 2017-04-04, tomorow is 2017-04-05 and the next is 2017-04-06";

            var matches = regex.Matches(anotherText);

            var count = 1;

            Console.WriteLine(new string('-', 10));

            foreach (/*!!! - not var: ->*/Match mathc in matches)
            {
                Console.WriteLine($"(04.{count}). {mathc.Value}");

                Console.WriteLine(new string('-', 10));

                count++;
            }

            Console.WriteLine();

            /*[URLhttp://www.google.de/]Google[/URL]*/
        }
    }
}
