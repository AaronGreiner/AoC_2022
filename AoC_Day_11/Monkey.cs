using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day_11
{
    internal class Monkey
    {
        internal List<BigInteger> Items = new List<BigInteger>();

        private List<Monkey> monkeys;
        private BigInteger prod = 1;

        internal int Number;
        internal BigInteger Count = 0;

        private int operation_num;
        private string operation_symbol;

        private int test_num;
        private int test_monkey_true;
        private int test_monkey_false;

        internal Monkey (int num, List<Monkey> monkeys)
        {
            Number = num;

            this.monkeys = monkeys;
        }

        internal void Init(string starting_items, string operation, string test, string test_true, string test_false)
        {
            foreach (string s in starting_items.Replace(" ", "").Split(','))
            {
                Items.Add(BigInteger.Parse(s));
            }

            operation_symbol = operation.Split(' ')[3];

            if (operation.Split(' ')[4] != "old")
            {
                operation_num = int.Parse(operation.Split(' ')[4]);
            }
            
            test_num = int.Parse(test.Split(' ')[2]);
            test_monkey_true = int.Parse(test_true.Split(' ')[3]);
            test_monkey_false = int.Parse(test_false.Split(' ')[3]);
        }

        internal void InspectItems(bool stressed)
        {
            if (prod == 1)
            {
                CalculateProd();
            }

            foreach (BigInteger item in Items)
            {
                BigInteger worry_level = CalculateWorryLevel(item, stressed);
                GetMonkey(worry_level).Items.Add(worry_level);
                Count++;
            }

            Items.Clear();
        }

        private BigInteger CalculateWorryLevel(BigInteger worry_level, bool stressed)
        {
            BigInteger ret = 0;
            BigInteger num;

            if (operation_num != 0)
            {
                num = (BigInteger)operation_num;
            }
            else
            {
                num = worry_level;
            }

            switch (operation_symbol)
            {
                case "+":
                    ret = BigInteger.Add(worry_level, num);
                    break;
                case "*":
                    ret = BigInteger.Multiply(worry_level, num);
                    break;
            }

            ret %= prod;

            return stressed ? ret : ret / 3;
        }

        private Monkey GetMonkey(BigInteger worry_level)
        {
            int monkey = worry_level % (BigInteger)test_num == 0 ? test_monkey_true : test_monkey_false;

            foreach (Monkey m in monkeys)
            {
                if (m.Number == monkey)
                {
                    return m;
                }
            }

            return null;
        }

        private void CalculateProd()
        {
            foreach (Monkey m in monkeys)
            {
                prod *= (BigInteger)m.test_num;
            }
        }
    }
}
