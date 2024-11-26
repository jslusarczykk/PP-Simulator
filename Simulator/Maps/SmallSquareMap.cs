using System.Drawing;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public SmallSquareMap(int size) : base(size, size) { }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
        }

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = p;

            switch (d)
            {
                case Direction.Up:
                    nextPoint = new Point(p.X, p.Y - 1);
                    break;
                case Direction.Down:
                    nextPoint = new Point(p.X, p.Y + 1);
                    break;
                case Direction.Left:
                    nextPoint = new Point(p.X - 1, p.Y);
                    break;
                case Direction.Right:
                    nextPoint = new Point(p.X + 1, p.Y);
                    break;
            }

            return Exist(nextPoint) ? nextPoint : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            throw new NotImplementedException("Diagonals are not implemented for this map.");
        }
    }
}
