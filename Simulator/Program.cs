using System;
using System.Drawing;

namespace Simulator
{
    internal class Program
    {
        public static void Lab5a()
        {
            Console.WriteLine("Testowanie tworzenia prostokątów:");

            try
            {
                Rectangle rect1 = new Rectangle(10, 5, 5, 10);
                Console.WriteLine($"Rect1: {rect1}");

                Point p1 = new Point(20, 25);
                Point p2 = new Point(15, 30);
                Rectangle rect2 = new Rectangle(p2, p1);
                Console.WriteLine($"Rect2: {rect2}");

                Rectangle rect3 = new Rectangle(10, 10, 10, 20);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Wyjątek: {ex.Message}");
            }

            Rectangle rect4 = new Rectangle(0, 0, 10, 10);
            Point insidePoint = new Point(5, 5);
            Point outsidePoint = new Point(15, 5);

            Console.WriteLine($"Czy prostokąt zawiera punkt (5, 5): {rect4.Contains(insidePoint)}");
            Console.WriteLine($"Czy prostokąt zawiera punkt (15, 5): {rect4.Contains(outsidePoint)}");

            Point start = new Point(10, 25);
            Console.WriteLine($"Punkt startowy: {start}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");
            Lab5a();
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
