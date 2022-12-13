using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_Day_8
{
    internal class Program
    {
        public static List<List<int>> trees = new List<List<int>>();

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            foreach (string s in input)
            {
                trees.Add(s.ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToList());
            }

            Console.WriteLine("Visible Trees from outside the Grid: " + GetVisibleTreeCount());
            Console.WriteLine("The highest Scenic Score possible: " + GetBestScenicScore());

            Console.ReadLine();
        }

        public static int GetVisibleTreeCount()
        {
            int count = 0;
            int height = 0;

            bool visible_north = false;
            bool visible_east = false;
            bool visible_south = false;
            bool visible_west = false;

            for (int i = 0; i < trees.Count; i++)
            {
                for (int j = 0; j < trees[i].Count; j++)
                {
                    height = trees[i][j];

                    visible_north = !Enumerable.Range(0, i).Any(x => trees[x][j] >= height);
                    visible_east = !Enumerable.Range(j + 1, trees[i].Count - j - 1).Any(x => trees[i][x] >= height);
                    visible_south = !Enumerable.Range(i + 1, trees.Count - i - 1).Any(x => trees[x][j] >= height);
                    visible_west = !Enumerable.Range(0, j).Any(x => trees[i][x] >= height);

                    if (visible_north || visible_east || visible_south || visible_west)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static int GetBestScenicScore()
        {
            int score_max = 0;
            int score = 0;
            int height = 0;

            List<int> trees_north;
            List<int> trees_east;
            List<int> trees_south;
            List<int> trees_west;

            int index_north = 0;
            int index_east = 0;
            int index_south = 0;
            int index_west = 0;

            int count_north = 0;
            int count_east = 0;
            int count_south = 0;
            int count_west = 0;

            for (int i = 1; i < trees.Count - 1; i++)
            {
                for (int j = 1; j < trees[i].Count - 1; j++)
                {
                    height = trees[i][j];

                    trees_north = trees.Take(i).Select(x => x[j]).ToList();
                    index_north = trees_north.FindLastIndex(x => x >= height);

                    if (index_north >= 0)
                    {
                        count_north = i - index_north;
                    }
                    else
                    {
                        count_north = trees_north.Count;
                    }

                    trees_east = trees[i].Skip(j + 1).Take(trees[i].Count - j - 1).Reverse().ToList();
                    index_east = trees_east.FindLastIndex(x => x >= height);

                    if (index_east >= 0)
                    {
                        count_east = trees[i].Count - j - index_east - 1;
                    }
                    else
                    {
                        count_east = trees_east.Count;
                    }

                    trees_south = trees.Skip(i + 1).Take(trees.Count - i - 1).Select(x => x[j]).Reverse().ToList();
                    index_south = trees_south.FindLastIndex(x => x >= height);

                    if (index_south >= 0)
                    {
                        count_south = trees.Count - i - index_south - 1;
                    }
                    else
                    {
                        count_south = trees_south.Count;
                    }

                    trees_west = trees[i].Take(j).ToList();
                    index_west = trees_west.FindLastIndex(x => x >= height);

                    if (index_west >= 0)
                    {
                        count_west = j - index_west;
                    }
                    else
                    {
                        count_west = trees_west.Count;
                    }

                    score = count_north * count_east * count_south * count_west;

                    if (score > score_max)
                    {
                        score_max = score;
                    }
                }
            }

            return score_max;
        }
    }
}
