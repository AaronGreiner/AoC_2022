using System;
using System.Collections.Generic;
using System.Drawing;

namespace AoC_Day_9
{
    internal class Knot
    {
        internal Point Pos = new Point(0, 0);
        internal List<Point> ListMoves = new List<Point>();

        internal Knot(Point pos)
        {
            Pos = pos;
            UpdateListMoves();
        }

        internal void Move(Point pos_ref)
        {

            bool x_ok = pos_ref.X >= Pos.X - 1 && pos_ref.X <= Pos.X + 1;
            bool y_ok = pos_ref.Y >= Pos.Y - 1 && pos_ref.Y <= Pos.Y + 1;

            if (x_ok && y_ok)
            {
                return;
            }

            if (pos_ref.X == Pos.X)
            {
                if (pos_ref.Y > Pos.Y)
                {
                    Pos.Y++;
                }
                else
                {
                    Pos.Y--;
                }
            }
            else if (pos_ref.Y == Pos.Y)
            {
                if (pos_ref.X > Pos.X)
                {
                    Pos.X++;
                }
                else
                {
                    Pos.X--;
                }
            }
            else
            {
                if (pos_ref.X > Pos.X)
                {
                    Pos.X++;
                }
                else
                {
                    Pos.X--;
                }

                if (pos_ref.Y > Pos.Y)
                {
                    Pos.Y++;
                }
                else
                {
                    Pos.Y--;
                }
            }

            UpdateListMoves();
        }

        internal void Move(String direction)
        {
            switch (direction)
            {
                case "U":
                    Pos.Y--;
                    break;
                case "R":
                    Pos.X++;
                    break;
                case "D":
                    Pos.Y++;
                    break;
                case "L":
                    Pos.X--;
                    break;
            }

            UpdateListMoves();
        }

        private void UpdateListMoves()
        {
            foreach (Point p in ListMoves)
            {
                if (p.X == Pos.X && p.Y == Pos.Y)
                {
                    return;
                }
            }

            ListMoves.Add(new Point(Pos.X, Pos.Y));
        }
    }
}
