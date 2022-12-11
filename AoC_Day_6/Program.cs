using System;
using System.IO;
using System.Linq;

namespace AoC_Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = File.ReadAllText(@"../../input.txt").ToCharArray();
            int first_marker = 0;
            int first_marker_bonus = 0;

            for (int i = 0; i < input.Length - 4; i++)
            {
                if (CheckUnique(input.Skip(i).Take(4).ToArray()))
                {
                    first_marker = i + 4;
                    break;
                }
            }

            for (int i = 0; i < input.Length - 14; i++)
            {
                if (CheckUnique(input.Skip(i).Take(14).ToArray()))
                {
                    first_marker_bonus = i + 14;
                    break;
                }
            }

            Console.WriteLine("Number of Chars with Marker 4: " + first_marker);
            Console.WriteLine("Number of Chars with Marker 14: " + first_marker_bonus);

            Console.ReadLine();
        }

        private static bool CheckUnique(char[] chars)
        {
            return chars.Length == chars.Distinct().ToArray().Length;
        }
    }
}
