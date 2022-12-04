using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            List<int> sections1;
            List<int> sections2;

            int sum_full_intersect = 0;
            int sum_intersect = 0;

            foreach (string s in input)
            {
                sections1 = GetSectionList(
                    int.Parse(s.Split(',')[0].Split('-')[0]),
                    int.Parse(s.Split(',')[0].Split('-')[1]));

                sections2 = GetSectionList(
                    int.Parse(s.Split(',')[1].Split('-')[0]),
                    int.Parse(s.Split(',')[1].Split('-')[1]));

                if (FullIntersect(sections1, sections2))
                {
                    sum_full_intersect++;
                }

                if (Intersect(sections1, sections2))
                {
                    sum_intersect++;
                }
            }

            Console.WriteLine("Full Intersect: " + sum_full_intersect);
            Console.WriteLine("Intersect: " + sum_intersect);

            Console.ReadLine();
        }

        private static List<int> GetSectionList(int start, int end)
        {
            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private static bool FullIntersect(List<int> list1, List<int> list2)
        {
            int count = list1.Intersect(list2).Count();

            if (count == list1.Count() || count == list2.Count())
            {
                return true;
            }

            return false;
        }

        private static bool Intersect(List<int> list1, List<int> list2)
        {
            if (list1.Intersect(list2).Count() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
