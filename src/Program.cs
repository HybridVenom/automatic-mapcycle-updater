using System;
using System.IO;
using System.Collections.Generic;

namespace AutoMapUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AutoMapcycleUpdater";

            List<FileInfo> currDirFiles = new List<FileInfo>(new DirectoryInfo(@"./").GetFiles());

            bool srcdsExists = false; // Assume wrong directory

            PrintBanner();

            WriteLine_Blue("[i] - Looking for 'srcds.exe'...");

            foreach (FileInfo currFile in currDirFiles)
                if (currFile.Name == "srcds.exe")
                {
                    srcdsExists = true;
                    break;
                }

            if (srcdsExists)
            {
                Console.Write("Enter map prefix (ex. 'de_', 'bhop_'): ");
                Console.ForegroundColor = ConsoleColor.Green;
                string prefix = Console.ReadLine().Trim();
                Console.ResetColor();

                DirectoryInfo di = new DirectoryInfo(@".\csgo\maps");
                FileInfo[] files = di.GetFiles("*.bsp");

                StreamWriter streamWriter = new StreamWriter(@".\csgo\mapcycle.txt");

                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (FileInfo file in files)
                {
                    if (file.Name.StartsWith(prefix))
                    {
                        streamWriter.WriteLine(file.Name.Split('.')[0]);
                        Console.WriteLine("[i] - mapcycle.txt <- " + file.Name);
                    }
                }
                Console.ResetColor();
                streamWriter.Close();
            }
            else
            {
                WriteLine_Red("[!] - srcds.exe NOT FOUND!");
                WriteLine_Blue("[i] - I might be located in the wrong directory, place me in the same directory as 'srcds.exe'...");
            }
            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }

        private static void PrintBanner()
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| AutoMapcycleUpdater  By HybridVenom   |");
            Console.WriteLine("|         <3         STEAM_0:1:18101474 |");
            Console.WriteLine("+---------------------------------------+\n");
        }

        private static void WriteLine_Blue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void WriteLine_Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
