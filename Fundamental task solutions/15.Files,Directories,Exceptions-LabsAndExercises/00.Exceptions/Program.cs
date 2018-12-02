namespace _00.Exceptions
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        //public static void Main()
        //{
        //    Exception exception = new IOException("Error.");
        //    //Console.WriteLine(exception);
        //    throw exception;
        //}

        public static void Main()
        {
            File.WriteAllText("../../DemoExceptions", "10");
            //Exception exception = new IOException("Error! The file dose note exist.");
            //Console.WriteLine(exception.StackTrace);

            //// handling exceptions
            //try
            //{
            //    // the code that potentiali throw a exceptions
            //    File.ReadAllLines("UnExistent.txt");
            //}
            //catch (Exception e)// for seeng waht kind exception we have
            //{
            //    Console.WriteLine(e.StackTrace);
            //    // wath is wrong
            //    //throw exception;
            //}

            try
            {
                //string number = File.ReadAllText("../../DemoExceptions");
                //string number = File.ReadAllText("../../DemoExceptions1");
                string number = File.ReadAllText("../../DemoExceptions2.txt");

                var delimeter = int.Parse(number);

                Console.WriteLine(156 / delimeter);
            }
            catch (IOException e)
            {
                Console.WriteLine("Problem loading file....");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Can not divide by zero!");
            }
            finally
            {
                Console.WriteLine("Try again with valid input");
            }
        }
    }
}
