using Simulator.Maps;
using System;
using System.Drawing;

namespace Simulator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");
        }
    }

    public static class PointExtensions
    {
        // Metoda Next obsługująca cztery kierunki
        public static Point Next(this Point point, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Point(point.X, point.Y - 1);
                case Direction.Down:
                    return new Point(point.X, point.Y + 1);
                case Direction.Left:
                    return new Point(point.X - 1, point.Y);
                case Direction.Right:
                    return new Point(point.X + 1, point.Y);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }

}
