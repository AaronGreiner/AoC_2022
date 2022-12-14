using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AoC_Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            Rope rope = new Rope(2);
            Rope rope_bonus = new Rope(10);

            foreach (string s in input)
            {
                string[] strings = s.Split(' ');

                rope.Move(strings[0], int.Parse(strings[1]));
                rope_bonus.Move(strings[0], int.Parse(strings[1]));
            }

            Console.WriteLine("Rope with 2 Knots: " + rope.GetCountMovesLastKnot());
            Console.WriteLine("Rope with 10 Knots: " + rope_bonus.GetCountMovesLastKnot());

            Console.ReadLine();
        }
    }
}
