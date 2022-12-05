using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace AoC_Day_5
{
    internal class Program
    {
        private static List<List<char>> container;
        private static List<List<char>> container_bonus;

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            string result = "";
            string result_bonus = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    InitLists(input.Take(i - 1).ToArray());
                    break;
                }
            }

            foreach (string s in input)
            {
                if (s.StartsWith("move"))
                {
                    string[] split = s.Split(' ');
                    Move(int.Parse(split[1]), int.Parse(split[3]) - 1, int.Parse(split[5]) - 1);
                    MoveBonus(int.Parse(split[1]), int.Parse(split[3]) - 1, int.Parse(split[5]) - 1);
                }
            }

            foreach (List<char> stack in container)
            {
                result += stack.Last().ToString();
            }

            foreach (List<char> stack in container_bonus)
            {
                result_bonus += stack.Last().ToString();
            }

            Console.WriteLine("Container on Top of each Stack (CrateMover 9000): " + result);
            Console.WriteLine("Container on Top of each Stack (CrateMover 9001): " + result_bonus);

            Console.ReadLine();
        }

        private static void InitLists(string[] input)
        {
            container = new List<List<char>>();
            container_bonus = new List<List<char>>();

            int columns = (input[0].Length + 1) / 4;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == input.Length - 1)
                    {
                        container.Add(new List<char>());
                        container_bonus.Add(new List<char>());
                    }

                    char c = input[i].ToCharArray()[j * 4 + 1];

                    if (Char.IsLetter(c))
                    {
                        container[j].Add(c);
                        container_bonus[j].Add(c);
                    }
                }
            }
        }

        private static void Move(int move_count, int col1, int col2)
        {
            if (move_count <= 0)
            {
                return;
            }

            container[col2].Add(container[col1].Last());
            container[col1].RemoveAt(container[col1].Count - 1);

            Move(move_count - 1, col1, col2);
        }

        private static void MoveBonus(int move_count, int col1, int col2)
        {
            List<char> temp = container_bonus[col1].Skip(container_bonus[col1].Count - move_count).ToList();

            container_bonus[col1].RemoveRange(container_bonus[col1].Count - move_count, move_count);
            container_bonus[col2].AddRange(temp);
        }
    }
}
