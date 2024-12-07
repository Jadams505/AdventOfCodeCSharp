using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using Location = (int Row, int Col);

namespace AdventOfCode.Days._2024;

internal class Day6_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<string> Map { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach(var line in contents)
        {
            Map.Add(line);
        }
    }

    public Location GetStart()
    {
        var row = Map.Index().First(x => x.Item.Contains('^'));
        return (row.Index, row.Item.IndexOf('^'));
    }

    public Location Up(Location pos) => (pos.Row - 1, pos.Col);
    public Location Down(Location pos) => (pos.Row + 1, pos.Col);
    public Location Left(Location pos) => (pos.Row, pos.Col - 1);
    public Location Right(Location pos) => (pos.Row, pos.Col + 1);

    public char Get(Location pos) => Map[pos.Row][pos.Col];

    public bool ValidPoint(Location pos)
    {
        if (pos.Row < 0 || pos.Row >= Map.Count)
            return false;
        if (pos.Col < 0 || pos.Col >= Map[pos.Row].Length)
            return false;

        return true;
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Direction Rotate90(Direction cur) => cur switch
    {
        Direction.Up => Direction.Right,
        Direction.Down => Direction.Left,
        Direction.Left => Direction.Up,
        Direction.Right => Direction.Down,
        _ => throw new NotSupportedException()
    };

    public delegate Location MoveAction(Location pos);

    public HashSet<Location> CouldBeObstruction = [];

    public (Location Loc, Direction Dir) Move(Location start, Direction dir, MoveAction action)
    {
        var next = action(start);
        if (!ValidPoint(next)) return (next, dir);
        if (Get(next) is '#')
        {
            var rotate = Rotate90(dir);
            return (start, rotate);
        }

        return (next, dir);
    }

    // Precondition start is not a #
    public bool CheckObstruction(Location start, Direction dir)
    {
        if (dir is Direction.Up)
        {
            if (Map[start.Row].IndexOf('#', start.Col) != -1) return true;
        }
        if (dir is Direction.Down)
        {

        }
        return false;
    }

    public (Location Loc, Direction Dir) Move(Location start, Direction dir) => dir switch
    {
        Direction.Up => Move(start, dir, Up),
        Direction.Down => Move(start, dir, Down),
        Direction.Left => Move(start, dir, Left),
        Direction.Right => Move(start, dir, Right),
        _ => throw new NotSupportedException()
    };

    public List<(Location Loc, Direction Dir)> OriginalPath = [];

    public override long GetSolution1()
    {
        (Location Loc, Direction Dir) curr = (GetStart(), Direction.Up);
        while(ValidPoint(curr.Loc))
        {
            OriginalPath.Add(curr);
            curr = Move(curr.Loc, curr.Dir);
        }
        return OriginalPath.Select(path => path.Loc).Distinct().Count();
    }

    public void PrintSolution1()
    {

    }

    public override long GetSolution2()
    {
        HashSet<(Location, Direction)> loop = [];
        (Location Loc, Direction Dir) start = (GetStart(), Direction.Up);
        (Location Loc, Direction Dir) curr = (GetStart(), Direction.Up);
        int loopCount = 0;
        foreach(var point in OriginalPath.DistinctBy(x => x.Loc).Skip(1))
        {
            curr = start;
            var s = Map[point.Loc.Row].ToCharArray();
            var old = s[point.Loc.Col];
            s[point.Loc.Col] = '#';

            Map[point.Loc.Row] = new string(s);
            loop.Clear();
            curr = start;
            while (true)
            {
                if (!ValidPoint(curr.Loc))
                {
                    break;
                }

                if (loop.Contains(curr))
                {
                    loopCount++;
                    break;
                }
                loop.Add(curr);
                curr = Move(curr.Loc, curr.Dir);
            }

            s[point.Loc.Col] = old;
            Map[point.Loc.Row] = new string(s);
        }
        
        return loopCount;
    }
}
