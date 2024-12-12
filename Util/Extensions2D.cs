namespace AdventOfCode.Util;

public record struct Location(int Row, int Col)
{
    public static implicit operator Location((int Row, int Col) pos)
    {
        return new(pos.Row, pos.Col);
    }
}

public enum Direction
{
    North,
    NorthEast,
    East,
    SourthEast,
    South,
    SouthWest,
    West,
    NorthWest,
}

public static class Extensions2D
{
    public static Location Up(this Location pos, int n = 1) => (pos.Row - n, pos.Col);
    public static Location Down(this Location pos, int n = 1) => (pos.Row + n, pos.Col);
    public static Location Left(this Location pos, int n = 1) => (pos.Row, pos.Col - n);
    public static Location Right(this Location pos, int n = 1) => (pos.Row, pos.Col + n);

    public static Direction? DirectionTo(this Location pos, Location other) => other.Minus(pos) switch
    {
        var (Row, Col) when Row > 0 && Col == 0 => Direction.South,
        var (Row, Col) when Row > 0 && Col > 0 => Direction.NorthEast,
        var (Row, Col) when Row == 0 && Col > 0 => Direction.East,
        var (Row, Col) when Row < 0 && Col > 0 => Direction.NorthWest,
        var (Row, Col) when Row < 0 && Col == 0 => Direction.North,
        var (Row, Col) when Row < 0 && Col < 0 => Direction.SouthWest,
        var (Row, Col) when Row == 0 && Col < 0 => Direction.West,
        _ => null
    };

    // maxRow and maxCol exclusive
    public static bool InBounds(this Location pos, int maxRow, int maxCol) =>
        pos.Row >= 0 && pos.Row < maxRow && pos.Col >= 0 && pos.Col < maxCol;

    /// <summary>
    /// Math.Abs(to - pos)
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static Location DeltaAbs(this Location pos, Location to) =>
        (Math.Abs(pos.Row - to.Row), Math.Abs(pos.Col - to.Col));

    /// <summary>
    /// to - pos
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static Location Delta(this Location pos, Location to) =>
        (to.Row - pos.Row, to.Col - pos.Col);

    public static Location Plus(this Location pos, Location other) =>
        (pos.Row + other.Row, pos.Col + other.Col);

    public static Location Minus(this Location pos, Location other) =>
        (pos.Row - other.Row, pos.Col - other.Col);


}
