using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");
            List<int> list = new List<int>();
            int sum = 0;

            foreach (string s in input)
            {
                if (s.Length > 0)
                {
                    sum += int.Parse(s);
                }
                else
                {
                    list.Add(sum);
                    sum = 0;
                }
            }

            list.Add(sum);
            list = list.OrderByDescending(x => x).ToList();

            List<int> list_top_3 = list.GetRange(0, 3);

            Console.WriteLine("Calories carried by Top 1: " + list.Max());
            Console.WriteLine("Calories carried by Top 3: " + list_top_3.Sum());

            Console.ReadLine();
        }
    }
}
