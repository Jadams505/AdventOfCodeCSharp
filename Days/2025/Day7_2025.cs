using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2025;

internal class Day7_2025 : Day2025
{
    public override Regex ParseString { get; }

    public char[][] Input = null!;

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath)
            .Select(arr => arr.ToCharArray())
            .ToArray();

        Input = contents;
    }

    public bool InBounds(Location l)
    {
        return l.InBounds(Input.Length, Input[0].Length);
    }

    public char Get(Location l) => Input[l.Row][l.Col];

    public Dictionary<Location, int> Cache = [];

    public int Navigate(Location start)
    {
        if (!InBounds(start))
            return 0;
        var curr = Get(start);
        if (curr == '^')
        {
            if (Cache.ContainsKey(start))
                return 0; // already counted it
            var left = Navigate(start.Left());
            var right = Navigate(start.Right());
            var count = left + right + 1;
            Cache[start] = count;
            return count;
        }
        return Navigate(start.Down());

    }

    // why don't I always just use longs :(
    public Dictionary<Location, long> Cache2 = [];

	public long Navigate2(Location start)
	{
		if (!InBounds(start))
			return 0;
        if (start.Row == Input.Length - 1)
            return 1;
		var curr = Get(start);
		if (curr == '^')
		{
			if (Cache2.ContainsKey(start))
			    return Cache2[start]; 
			var left = Navigate2(start.Left());
			var right = Navigate2(start.Right());
            var count = left + right;
            Cache2[start] = count;
            return count;
		}
		return Navigate2(start.Down());
	}

	public override long GetSolution1()
    {
        var start = new Location(0, Input[0].IndexOf('S'));
        int total = Navigate(start);
        return total;
    }

    public override long GetSolution2()
    {
		var start = new Location(0, Input[0].IndexOf('S'));
		var total = Navigate2(start);
		return total;
	}
}
