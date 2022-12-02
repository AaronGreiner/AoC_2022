using System;
using System.IO;

namespace AoC_Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");
            int total_score = 0;
            int total_score_bonus = 0;

            foreach (string s in input)
            {
                total_score += GetScore(s.ToCharArray()[0], s.ToCharArray()[2]);
                total_score_bonus += GetScore(s.ToCharArray()[0], GetShape(s.ToCharArray()[0], s.ToCharArray()[2]));
            }

            Console.WriteLine("My Strategy Score: " + total_score);
            Console.WriteLine("Elfs Strategy Score: " + total_score_bonus);

            Console.ReadLine();
        }

        private static int GetScore(char c1, char c2)
        {
            switch (c1) {
                case 'A': //Rock
                    switch (c2)
                    {
                        case 'X': //Rock
                            return 1 + 3;
                        case 'Y': //Paper
                            return 2 + 6;
                        case 'Z': //Scissors
                            return 3 + 0;
                    }
                    break;
                case 'B': //Paper
                    switch (c2)
                    {
                        case 'X': //Rock
                            return 1 + 0;
                        case 'Y': //Paper
                            return 2 + 3;
                        case 'Z': //Scissors
                            return 3 + 6;
                    }
                    break;
                case 'C': //Scissors
                    switch (c2)
                    {
                        case 'X': //Rock
                            return 1 + 6;
                        case 'Y': //Paper
                            return 2 + 0;
                        case 'Z': //Scissors
                            return 3 + 3;
                    }
                    break;
            }

            return 0;
        }

        private static char GetShape(char c1, char c2)
        {
            switch (c1)
            {
                case 'A': //Rock
                    switch (c2)
                    {
                        case 'X': //Lose
                            return 'Z';
                        case 'Y': //Draw
                            return 'X';
                        case 'Z': //Win
                            return 'Y';
                    }
                    break;
                case 'B': //Paper
                    switch (c2)
                    {
                        case 'X': //Lose
                            return 'X';
                        case 'Y': //Draw
                            return 'Y';
                        case 'Z': //Win
                            return 'Z';
                    }
                    break;
                case 'C': //Scissors
                    switch (c2)
                    {
                        case 'X': //Lose
                            return 'Y';
                        case 'Y': //Draw
                            return 'Z';
                        case 'Z': //Win
                            return 'X';
                    }
                    break;
            }

            return '-';
        }
    }
}
