using System.Drawing;

using System;
using Simulator;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }

        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be in range [5, 20].");
            }
            Size = size;
        }

        public override bool Exist(Point point)
        {
            return point.X >= 0 && point.X < Size && point.Y >= 0 && point.Y < Size;
        }

        public override Point Next(Point point, Direction direction)
        {
            int x = point.X;
            int y = point.Y;

            switch (direction)
            {
                case Direction.Up:
                    y = (y + 1) % Size;
                    break;
                case Direction.Down:
                    y = (y - 1 + Size) % Size;
                    break;
                case Direction.Left:
                    x = (x - 1 + Size) % Size;
                    break;
                case Direction.Right:
                    x = (x + 1) % Size;
                    break;
            }

            return new Point(x, y);
        }

        public override Point NextDiagonal(Point point, Direction direction)
        {
            int x = point.X;
            int y = point.Y;

            switch (direction)
            {
                case Direction.Up:
                    x = (x + 1) % Size;
                    y = (y + 1) % Size;
                    break;
                case Direction.Down:
                    x = (x - 1 + Size) % Size;
                    y = (y - 1 + Size) % Size;
                    break;
                case Direction.Left:
                    x = (x - 1 + Size) % Size;
                    y = (y + 1) % Size;
                    break;
                case Direction.Right:
                    x = (x + 1) % Size;
                    y = (y - 1 + Size) % Size;
                    break;
            }

            return new Point(x, y);
        }
    }
}
