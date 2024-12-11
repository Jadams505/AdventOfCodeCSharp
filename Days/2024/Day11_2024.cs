using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days._2024;
internal class Day11_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<int> Stones { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);
        foreach(var line in contents)
        {
            Stones.AddRange(Number().Matches(line).Select(n => int.Parse(n.Value)));
        }
    }

    public Dictionary<(long Num, int Blinks), long> Lookup = [];

    public long Solve(long num, int blinks)
    {
        if (Lookup.TryGetValue((num, blinks), out var count))
            return count;

        if (blinks is 0)
        {
            Lookup[(num, blinks)] = 1;
            return 1;
        }

        if (num == 0)
            return Solve(1, blinks - 1);

        var s = num.ToString().AsSpan();
        if (s.Length % 2 is 0)
        {
            var first = s[..(s.Length / 2)];
            var last = s[(s.Length / 2)..];

            var n1 = Solve(long.Parse(first), blinks - 1);
            var n2 = Solve(long.Parse(last), blinks - 1);

            Lookup[(num, blinks)] = n1 + n2;
            return n1 + n2;
        }
        return Solve(num * 2024, blinks - 1);
    }

    public override long GetSolution1()
    {
        var i = 25;
        long total = 0;
        foreach(var stone in Stones)
        {
            var count = Solve(stone, i);
            total += count;
        }
        return total;
    }

    public override long GetSolution2()
    {
        var i = 75;
        long total = 0;
        foreach (var stone in Stones)
        {
            var count = Solve(stone, i);
            total += count;
        }
        return total;
    }
}
