

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = base.Next(p, d);

            if (nextPoint == p) 
            {
                switch (d)
                {
                    case Direction.Up:
                        nextPoint = new Point(p.X, p.Y + 1);
                        break;
                    case Direction.Down:
                        nextPoint = new Point(p.X, p.Y - 1);
                        break;
                    case Direction.Left:
                        nextPoint = new Point(p.X + 1, p.Y);
                        break;
                    case Direction.Right:
                        nextPoint = new Point(p.X - 1, p.Y);
                        break;
                }

                if (!Exist(nextPoint)) // Jeśli odbicie nie jest możliwe, pozostaje w miejscu
                {
                    nextPoint = p;
                }
            }

            return nextPoint;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            throw new NotImplementedException("Diagonals are not implemented for this map.");
        }
    }
}