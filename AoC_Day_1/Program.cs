using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            foreach (string s in input)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
