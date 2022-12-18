using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AoC_Day_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");

            List<Monkey> monkeys = new List<Monkey>();
            List<Monkey> monkeys_bonus = new List<Monkey>();

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Trim();
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("Monkey"))
                {
                    Monkey monkey = new Monkey(int.Parse(input[i].Replace("Monkey ", "").Replace(":", "")), monkeys);

                    monkey.Init(
                        input[i + 1].Replace("Starting items: ", ""),
                        input[i + 2].Replace("Operation: ", ""),
                        input[i + 3].Replace("Test: ", ""),
                        input[i + 4].Replace("If true: ", ""),
                        input[i + 5].Replace("If false: ", ""));

                    monkeys.Add(monkey);

                    Monkey monkey_bonus = new Monkey(int.Parse(input[i].Replace("Monkey ", "").Replace(":", "")), monkeys_bonus);

                    monkey_bonus.Init(
                        input[i + 1].Replace("Starting items: ", ""),
                        input[i + 2].Replace("Operation: ", ""),
                        input[i + 3].Replace("Test: ", ""),
                        input[i + 4].Replace("If true: ", ""),
                        input[i + 5].Replace("If false: ", ""));

                    monkeys_bonus.Add(monkey_bonus);
                }
            }

            Play(20, monkeys, false);
            Console.WriteLine("Monkey Business after 20 Rounds: " + GetTotalMonkeyBusiness(2, monkeys));
            Play(10000, monkeys_bonus, true);
            Console.WriteLine("Monkey Business after 10000 Rounds (Stressed): " + GetTotalMonkeyBusiness(2, monkeys_bonus));

            Console.ReadLine();
        }

        private static void Play(int count, List<Monkey> monkeys, bool stressed)
        {
            if (count == 0)
            {
                return;
            }

            foreach (Monkey m in monkeys)
            {
                m.InspectItems(stressed);
            }

            Play(count - 1, monkeys, stressed);
        }

        private static BigInteger GetTotalMonkeyBusiness(int num, List<Monkey> monkeys)
        {
            BigInteger ret = 1;
            List<BigInteger> monkey_business = new List<BigInteger>();

            foreach (Monkey m in monkeys)
            {
                monkey_business.Add(m.Count);
            }

            monkey_business.Sort();

            monkey_business = monkey_business.Skip(monkey_business.Count - num).Take(num).ToList();

            foreach (BigInteger i in monkey_business)
            {
                ret *= i;
            }

            return ret;
        }
    }
}
