public static class DirectionParser
{
    /// <summary>
    /// Parses a string move into a Direction.
    /// </summary>
    /// <param name="move">The move string (e.g., "u", "d", "l", "r").</param>
    /// <returns>The corresponding Direction enum.</returns>
    public static Direction Parse(string move)
    {
        return move.ToLower() switch
        {
            "u" => Direction.Up,
            "d" => Direction.Down,
            "l" => Direction.Left,
            "r" => Direction.Right,
            _ => throw new ArgumentException($"Invalid move: {move}")
        };
    }
}
