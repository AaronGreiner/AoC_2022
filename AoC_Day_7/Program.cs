using System;
using System.IO;

namespace AoC_Day_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            int total_size = 0;
            int total_disc_space = 70000000;
            int space_needed = 30000000;
            int total_space_to_delete = 0;

            SystemDirectory root = null;
            SystemDirectory current = null;
            SystemDirectory dir_bonus = null;

            foreach (string line in input)
            {
                string[] strings = line.Split(' ');

                switch (strings[0])
                {
                    case "$": //Command
                        if (strings[1] == "cd")
                        {
                            switch (strings[2])
                            {
                                case "/":
                                    root = new SystemDirectory(null, strings[2]);
                                    current = root;
                                    break;
                                case "..":
                                    current = current.Parent;
                                    break;
                                default:
                                    current = current.GetDirectoryByName(strings[2]);
                                    break;
                            }
                        }
                        break;
                    case "dir": //Directory
                        current.Directories.Add(new SystemDirectory(current, strings[1]));
                        break;
                    default: //File
                        current.Files.Add(new SystemFile(strings[1], int.Parse(strings[0])));
                        break;
                }
            }

            total_space_to_delete = Math.Abs(total_disc_space - space_needed - root.GetTotalSize());

            foreach (SystemDirectory dir in root.GetListOfDiectories(0, 100000))
            {
                total_size += dir.GetTotalSize();
            }

            Console.WriteLine("Total Size of Directories less than 100000: " + total_size);


            foreach (SystemDirectory dir in root.GetListOfDiectories(total_space_to_delete, total_disc_space))
            {
                if (dir_bonus != null && dir_bonus.GetTotalSize() > dir.GetTotalSize())
                {
                    dir_bonus = dir;
                }
                else
                {
                    dir_bonus = dir;
                }
            }

            Console.WriteLine("Total Size of the Directory to delete: " + dir_bonus.GetTotalSize());

            Console.ReadLine();
        }
    }
}
