using System;
using System.Drawing;

namespace Simulator.Maps
{
    /// <summary>
    /// Represents a small square map with sizes ranging from 5 to 20 points.
    /// </summary>
    public abstract class SmallSquareMap : Map
    {
        private readonly Rectangle _Map;

        // Constructor for SmallSquareMap that calls the base Map constructor
        protected SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
            }
            if (sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
            }
            SizeX = sizeX;
            SizeY = sizeY;
            _Map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        }

        public int SizeX { get; }
        public int SizeY { get; }

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = p;

            switch (d)
            {
                case Direction.Up:
                    nextPoint = new Point(p.X, p.Y + 1);
                    break;
                case Direction.Down:
                    nextPoint = new Point(p.X, p.Y - 1);
                    break;
                case Direction.Left:
                    nextPoint = new Point(p.X - 1, p.Y);
                    break;
                case Direction.Right:
                    nextPoint = new Point(p.X + 1, p.Y);
                    break;
            }

            // Check if the next point is within bounds
            if (!Exist(nextPoint))
            {
                return p; // Stay at the same point if out of bounds
            }

            return nextPoint;
        }

        /// <summary>
        /// Returns the next diagonal position to the point in the given direction, rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>The next diagonal point or the same point if the move would go out of bounds.</returns>
        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextPoint = p;

            switch (d)
            {
                case Direction.UpRight:
                    nextPoint = new Point(p.X + 1, p.Y + 1);
                    break;
                case Direction.UpLeft:
                    nextPoint = new Point(p.X - 1, p.Y + 1);
                    break;
                case Direction.DownRight:
                    nextPoint = new Point(p.X + 1, p.Y - 1);
                    break;
                case Direction.DownLeft:
                    nextPoint = new Point(p.X - 1, p.Y - 1);
                    break;
            }

            // Check if the next point is within bounds
            if (!Exist(nextPoint))
            {
                return p; // Stay at the same point if out of bounds
            }

            return nextPoint;
        }
    }
}
