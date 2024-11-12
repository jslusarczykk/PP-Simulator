namespace Simulator
{
    public readonly struct GridPoint
    {
        public readonly int X, Y;
        public GridPoint(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"({X}, {Y})";

        public GridPoint Next(Direction direction)
        {
            int new_x = X;
            int new_y = Y;
            switch (direction)
            {
                case Direction.Right: new_x++; break;
                case Direction.Left: new_x--; break;
                case Direction.Down: new_y--; break;
                case Direction.Up: new_y++; break;
            }
            return new GridPoint(new_x, new_y);
        }

        public GridPoint NextDiagonal(Direction direction)
        {
            int new_x = X;
            int new_y = Y;
            switch (direction)
            {
                case Direction.Right: new_x++; new_y--; break;
                case Direction.Left: new_x--; new_y++; break;
                case Direction.Down: new_x--; new_y--; break;
                case Direction.Up: new_x++; new_y++; break;
            }
            return new GridPoint(new_x, new_y);
        }
    }
}
