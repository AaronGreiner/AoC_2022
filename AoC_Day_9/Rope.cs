using System.Collections.Generic;
using System.Drawing;

namespace AoC_Day_9
{
    internal class Rope
    {
        private List<Knot> knots = new List<Knot>();

        internal Rope(int num_knots)
        {
            for (int i = 0; i < num_knots; i++)
            {
                knots.Add(new Knot(new Point(0, 0)));
            }
        }

        internal void Move(string direction, int count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < knots.Count; j++)
                {
                    if (j == 0)
                    {
                        knots[j].Move(direction);
                    }
                    else
                    {
                        knots[j].Move(knots[j - 1].Pos);
                    }
                }
            }
        }

        internal int GetCountMovesLastKnot()
        {
            return knots[knots.Count - 1].ListMoves.Count;
        }
    }
}
