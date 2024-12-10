namespace AdventOfCode.Util;

public record struct Location(int Row, int Col)
{
    public static implicit operator Location((int Row, int Col) pos)
    {
        return new(pos.Row, pos.Col);
    }
}

public static class Extensions2D
{
    public static Location Up(this Location pos, int n = 1) => (pos.Row - n, pos.Col);
    public static Location Down(this Location pos, int n = 1) => (pos.Row + n, pos.Col);
    public static Location Left(this Location pos, int n = 1) => (pos.Row, pos.Col - n);
    public static Location Right(this Location pos, int n = 1) => (pos.Row, pos.Col + n);

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
