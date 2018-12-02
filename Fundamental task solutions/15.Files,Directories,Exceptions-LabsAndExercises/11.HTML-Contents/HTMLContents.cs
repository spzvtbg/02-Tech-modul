namespace _11.HTML_Contents
{
    using System;
    using System.IO;
    using System.Linq;

    public class HTMLContents
    {
        public static void Main()
        {
            //Directory.CreateDirectory("../../HTML");

            //File.Create("../../HTML/body.txt");

            //File.Create("../../HTML/head.txt");

            var entered = Console.ReadLine().Split(' ').ToList();

            while (entered[0] != "exit")
            {
                if (entered[0] == "title")
                {
                    var headIn = "<!DOCTYPE>\r\n" + "<html>\r\n" + "<head>\r\n" +
                        $"\t<title>{string.Join(" ", entered.Skip(1))}</title>\r\n" + "</head>\r\n" + "<body>\r\n";

                    File.WriteAllText("../../HTML/head.txt", headIn);
                }
                else
                {
                    var bodyIn = $"\t<{entered[0]}>{string.Join(" ",entered.Skip(1))}</{entered[0]}>\r\n";

                    File.AppendAllText("../../HTML/body.txt", bodyIn);
                }
                entered = Console.ReadLine().Split(' ').ToList();
            }

            var head = File.ReadAllLines("../../HTML/head.txt").ToList();

            var body = File.ReadAllLines("../../HTML/body.txt").ToList();

            var end = "</body>\r\n" + "</html>";

            File.AppendAllLines("../../HTML/index.html", head);

            File.AppendAllLines("../../HTML/index.html", body);

            File.AppendAllText("../../HTML/index.html", end);

            //File.Delete("../../HTML/index.html");

            //File.Delete("../../HTML/index.html");

            //File.Delete("../../HTML/index.html");
        }
    }
}
