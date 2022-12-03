using System;
using System.IO;

namespace AoC_Day_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");
            int sum_prio = 0;

            int curent_comp_bonus = 0;
            string[] comps_bonus = new string[3];
            int sum_prio_bonus = 0;

            foreach (string s in input)
            {
                // First Star:
                string comp1 = s.Substring(0, s.Length / 2);
                string comp2 = s.Substring(s.Length / 2);
                char c = GetCommonChar(comp1, comp2);
                sum_prio += GetCharPrio(c);

                // Second Star:
                if (curent_comp_bonus > 2)
                {
                    curent_comp_bonus = 0;
                }
                comps_bonus[curent_comp_bonus] = s;

                if (curent_comp_bonus == 2)
                {
                    char c_bonus = GetCommonChar(comps_bonus[0], comps_bonus[1], comps_bonus[2]);
                    sum_prio_bonus += GetCharPrio(c_bonus);
                }

                curent_comp_bonus++;
            }

            Console.WriteLine("Sum Common Types: " + sum_prio);
            Console.WriteLine("Sum Common between 3 Elves: " + sum_prio_bonus);

            Console.ReadLine();
        }

        private static char GetCommonChar(string comp1, string comp2)
        {
            foreach (char c1 in comp1.ToCharArray())
            {
                foreach (char c2 in comp2.ToCharArray())
                {
                    if (c1 == c2)
                    {
                        return c1;
                    }
                }
            }

            return '-';
        }

        private static char GetCommonChar(string comp1, string comp2, string comp3)
        {
            foreach (char c1 in comp1.ToCharArray())
            {
                foreach (char c2 in comp2.ToCharArray())
                {
                    foreach (char c3 in comp3.ToCharArray())
                    {
                        if (c1 == c2 && c2 == c3)
                        {
                            return c1;
                        }
                    }
                }
            }

            return '-';
        }

        private static int GetCharPrio(char c)
        {
            if (Char.IsUpper(c))
            {
                return (int)c - 38;
            }
            else
            {
                return (int)c - 96;
            }
        }
    }
}
