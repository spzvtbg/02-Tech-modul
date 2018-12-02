namespace _00.Directories_Class_Methoods
{
    using System.IO;

    public class Program
    {
        //// ---( CreateDirectory )---
        //// Cann't delete directory while is not empty;
        //public static void Main()
        //{
        //    Directory.CreateDirectory("../../DemoDirectory");
        //    File.Create("../../DemoDirectory/DemoFile.txt");
        //    Directory.CreateDirectory("../../DemoDirectory/InDemoDirectory");
        //}

        // ---( Move-Files or Directories )---
        public static void Main()
        {
            //Directory.CreateDirectory("../../MoveDirectory/InMoveDirectory");

            //File.WriteAllText("../../MoveDirectory/InMoveDirectory/MoveTest.txt", "This is test for moving directories and files...");

            //File.Delete("../../MoveDirectory/InMoveDirectory/MoveTest");

            //Directory.CreateDirectory("../../ToDirectory");

            //Directory.Move("../../MoveDirectory/InMoveDirectory", "../../ToDirectory");

            //Directory.Move("../../MoveDirectory", "../../ToDirectory");

            Directory.Move("../../ToDirectory", "../../MoveDirectory");
        }
    }
}
