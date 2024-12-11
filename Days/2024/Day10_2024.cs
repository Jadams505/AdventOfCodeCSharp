using AdventOfCode.Util;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day10_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<string> Map { get; } = [];

    public Dictionary<Location, int> TrailheadScores = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach (var line in contents)
        {
            Map.Add(line);
        }
    }

    public bool IsValid(Location pos) => pos.InBounds(Map.Count, Map[0].Length);
    public int Get(Location pos) => (int)char.GetNumericValue(Map[pos.Row][pos.Col]);

    public HashSet<Location> Found = [];

    public int GetScore(Location start, Location next, HashSet<Location> found)
    {
        if (!IsValid(start))
            return 0;

        var startNum = Get(start);

        if (!IsValid(next)) 
            return 0;

        var nextNum = Get(next);
        if (startNum + 1 != nextNum) 
            return 0;

        if (nextNum == 9)
        {
            return found.Add(next) ? 1 : 0;
        }

        var direction = start.DirectionTo(next);
        int up = GetScore(next, next.Up(), found);
        int down = GetScore(next, next.Down(), found);
        int right = GetScore(next, next.Right(), found);
        int left = GetScore(next, next.Left(), found);
        return up + down + right + left;
    }

    public int GetScore(Location start)
    {
        HashSet<Location> found = [];

        return GetScore(start, start.Up(), found) +
            GetScore(start, start.Down(), found) +
            GetScore(start, start.Right(), found) +
            GetScore(start, start.Left(), found);
    }
        

    // 244 too low
    public override long GetSolution1()
    {
        var total = 0;
        for (int i = 0; i <  Map.Count; ++i)
        {
            for (int j = 0; j < Map[i].Length; ++j)
            {
                var curr = Get((i, j));
                if (curr is 0)
                {
                    var score = GetScore((i, j));
                    total += score;
                }
            }
        }
        return total;
    }

    public int GetScore2(Location start, Location next)
    {
        if (!IsValid(start))
            return 0;

        var startNum = Get(start);

        if (!IsValid(next))
            return 0;

        var nextNum = Get(next);
        if (startNum + 1 != nextNum)
            return 0;

        if (nextNum == 9)
        {
            return 1;
        }

        var direction = start.DirectionTo(next);
        int up = GetScore2(next, next.Up());
        int down = GetScore2(next, next.Down());
        int right = GetScore2(next, next.Right());
        int left = GetScore2(next, next.Left());
        return up + down + right + left;
    }

    public int GetScore2(Location start)
    {
        return GetScore2(start, start.Up()) +
            GetScore2(start, start.Down()) +
            GetScore2(start, start.Right()) +
            GetScore2(start, start.Left());
    }

    public override long GetSolution2()
    {
        var total = 0;
        for (int i = 0; i < Map.Count; ++i)
        {
            for (int j = 0; j < Map[i].Length; ++j)
            {
                var curr = Get((i, j));
                if (curr is 0)
                {
                    var score = GetScore2((i, j));
                    total += score;
                }
            }
        }
        return total;
    }
}
