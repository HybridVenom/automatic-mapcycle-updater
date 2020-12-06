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

            WriteLine_Cyan("[i] - Looking for 'srcds.exe'...");

            foreach (FileInfo currFile in currDirFiles)
                if (currFile.Name == "srcds.exe")
                {
                    srcdsExists = true;
                    break;
                }

            if (srcdsExists)
            {
                Console.Write("Enter one or more map prefixes (ex. one: 'de_', more: 'bhop_/kz_'): ");
                Console.ForegroundColor = ConsoleColor.Green;
                string prefixRead = Console.ReadLine().Trim();
                Console.ResetColor();

                string[] prefixArr = prefixRead.Split('/');

                DirectoryInfo di = new DirectoryInfo(@".\csgo\maps");
                FileInfo[] files = di.GetFiles("*.bsp");

                StreamWriter streamWriter = new StreamWriter(@".\csgo\mapcycle.txt");

                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (FileInfo file in files)
                    for (int i = 0; i < prefixArr.Length; i++)
                        if (file.Name.StartsWith(prefixArr[i]))
                        {
                            streamWriter.WriteLine(file.Name.Split('.')[0]);
                            Console.WriteLine("[i] - mapcycle.txt <- " + file.Name);
                            break;
                        }

                Console.ResetColor();
                streamWriter.Close();
            }
            else
            {
                WriteLine_Red("[!] - srcds.exe NOT FOUND!");
                WriteLine_Cyan("[i] - I might be located in the wrong directory, place me in the same directory as 'srcds.exe'...");
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

        private static void WriteLine_Cyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
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
