using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_Day_10
{
    internal class Program
    {
        private static int cycle = 0;
        private static int value = 1;

        private static List<int> signals = new List<int>();

        private static List<bool> current_output;
        private static List<List<bool>> output = new List<List<bool>>();

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            for (int i = 0; i < input.Length; i++)
            {
                string[] strings = input[i].Split(' ');

                switch (strings[0])
                {
                    case "noop":
                        UpdateCycle();
                        break;
                    case "addx":
                        UpdateValue(int.Parse(strings[1]));
                        break;
                }
            }

            Console.WriteLine("Total Signal Strength: " + signals.Sum());
            Console.WriteLine("Output on CRT:");
            PrintOutput();

            Console.ReadLine();
        }

        private static void PrintOutput()
        {
            output.Add(current_output);

            for (int i = 0; i < output.Count; i++)
            {
                for (int j = 0; j < output[i].Count; j++)
                {
                    Console.Write(output[i][j] ? "#" : ".");
                }
                Console.WriteLine();
            }
        }

        private static void UpdateCycle()
        {
            CheckOutput();
            cycle++;
            CheckSignals();
        }

        private static void CheckSignals()
        {
            int check = 20;

            for (int i = 0; i < cycle / 40 + 1; i++)
            {
                if (cycle == check)
                {
                    signals.Add(cycle * value);
                    return;
                }

                check += 40;
            }
        }

        private static void CheckOutput()
        {
            if (current_output == null)
            {
                current_output = new List<bool>();
            }

            if (cycle % 40 == 0 && cycle != 0)
            {
                if (current_output != null)
                {
                    output.Add(current_output);
                }

                current_output = new List<bool>();
            }

            current_output.Add(Math.Abs(value - (cycle % 40)) <= 1);
        }

        private static void UpdateValue(int v)
        {
            UpdateCycle();
            UpdateCycle();
            value += v;
        }
    }
}
