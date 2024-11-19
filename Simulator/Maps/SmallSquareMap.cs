using System;
using System;
using System.Drawing;

namespace Simulator.Maps
{
    /// <summary>
    /// Represents a small square map with sizes ranging from 5 to 20 points.
    /// </summary>
    public class SmallSquareMap : Map
    {
        private int size;

        /// <summary>
        /// Gets the size of the map.
        /// </summary>
        public int Size => size;

        /// <summary>
        /// Initializes a new instance of the SmallSquareMap class with the specified size.
        /// </summary>
        /// <param name="size">Size of the square map. Must be between 5 and 20 inclusive.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the size is outside the allowed range of 5 to 20.</exception>
        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
            }

            this.size = size;
        }

        /// <summary>
        /// Checks if the given point is within the bounds of the map.
        /// </summary>
        /// <param name="p">The point to check.</param>
        /// <returns>True if the point is within the map; otherwise, false.</returns>
        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < size && p.Y >= 0 && p.Y < size;
        }

        /// <summary>
        /// Returns the next position to the point in the given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>The next point or the same point if the move would go out of bounds.</returns>
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
