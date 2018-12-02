using System;
namespace Notifications
{
    public class printMessage
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string result = Console.ReadLine();

                string output = string.Empty;
                if (result == "success")
                {
                    string operation1 = Console.ReadLine();
                    string message = Console.ReadLine();
                    output = PrintSuccess(operation1, message);
                }
                else if (result == "error")
                {
                    string operation0 = Console.ReadLine();
                    int code = int.Parse(Console.ReadLine());
                    output = PrintError(operation0, code);
                }
                Console.WriteLine(output);
            }
        }
        static string PrintSuccess(string operation, string message)
        {
            string result = $"Successfully executed {operation}." +
                    "\n==============================" +
                    $"\nMessage: {message}.";
            return result;
        }
        static string PrintError(string operation, int code)
        {
            string reason = code >= 0 ? "Invalid Client Data" : "Internal System Failure";
            string result = $"Error: Failed to execute {operation}." +
                    "\n==============================" +
                    $"\nError Code: {code}." + $"\nReason: {reason}.";
            return result;
        }
    }
}
