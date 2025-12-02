using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days._2025;

internal class Day1_2025 : Day2025
{
    public override Regex ParseString { get; } = new(@"([R|L])(\d+)");

    public List<Rotation> Instructions { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadLines(SolutionFilePath);

        foreach (var s in contents)
        {
            var m = ParseString.Match(s);
            var dir = m.Groups[1].Value;
            var direction = dir == "R" ? Direction.R : Direction.L;
            var amount = int.Parse(m.Groups[2].Value);

            Instructions.Add(new(direction, amount));
        }
    }

    public override long GetSolution1()
    {
        int start = 50;
        int zeroes = 0;
        foreach (var r in Instructions)
        {
            start = r.Move(start);
            if (start == 0)
                zeroes++;
        }
        return zeroes;
    }

    public override long GetSolution2()
    {
		int start = 50;
		int zeroes = 0;
		foreach (var r in Instructions)
		{
			start = r.Move2(start, out int passZeroCount);
            zeroes += passZeroCount;
		}
        return zeroes;
	}
}

public enum Direction
{
    L,
    R
}

public record Rotation(Direction Direction, int Amount)
{
    public int Move(int current) => Direction switch
    {
        Direction.L => (current + (100 - (Amount % 100))) % 100,
        Direction.R => (current + Amount) % 100,
        _ => current
    };

    public int Move2(int current, out int passZeroCount)
    {
        int min = Amount / 100;
        passZeroCount = min;
        if (Direction is Direction.L)
        {
            int remain = Amount - min * 100;
            if (current != 0 && current - remain <= 0) passZeroCount++;
		}
        else if (Direction is Direction.R)
        {
            int remain = Amount - min * 100;
            if (current != 0 && current + remain >= 100) passZeroCount++;
        }
        return Move(current);
    }
}
