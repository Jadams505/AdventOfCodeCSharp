using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2025;

internal class Day4_2025 : Day2025
{
    public override Regex ParseString { get; }

    public List<string> ToiletPaper { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        ToiletPaper.AddRange(contents);

    }

    public char Get(Location pos) => ToiletPaper[pos.Row][pos.Col];

    public bool HasToiletPaper(Location pos)
    {
        if (!pos.InBounds(ToiletPaper.Count, ToiletPaper[0].Length))
            return false;
        return Get(pos) == '@';
    }

    public int CountAdjacent(Location pos)
    {
        int count = 0;
        if (HasToiletPaper(pos.Up())) count++;
		if (HasToiletPaper(pos.Up().Right())) count++;
		if (HasToiletPaper(pos.Up().Left())) count++;
		if (HasToiletPaper(pos.Left())) count++;
		if (HasToiletPaper(pos.Right())) count++;
		if (HasToiletPaper(pos.Down())) count++;
		if (HasToiletPaper(pos.Down().Right())) count++;
		if (HasToiletPaper(pos.Down().Left())) count++;
        return count;
	}

    public override long GetSolution1()
    {
        var count = 0;
        for (int i = 0; i < ToiletPaper.Count; ++i)
        {
            for (int j = 0; j < ToiletPaper[i].Length; ++j)
            {
                var location = new Location(i, j);
                if (!HasToiletPaper(location))
                    continue;
                int adjCount = CountAdjacent(location);
                if (adjCount < 4)
                    count++;
            }
        }
        return count;
    }

	public char Get(char[][] array, Location pos) => array[pos.Row][pos.Col];

	public bool HasToiletPaper(char[][] array, Location pos)
	{
		if (!pos.InBounds(array.Length, array[0].Length))
			return false;
		return Get(array, pos) == '@';
	}

	public int CountAdjacent(char[][] array, Location pos)
	{
		int count = 0;
		if (HasToiletPaper(array, pos.Up())) count++;
		if (HasToiletPaper(array, pos.Up().Right())) count++;
		if (HasToiletPaper(array, pos.Up().Left())) count++;
		if (HasToiletPaper(array, pos.Left())) count++;
		if (HasToiletPaper(array, pos.Right())) count++;
		if (HasToiletPaper(array, pos.Down())) count++;
		if (HasToiletPaper(array, pos.Down().Right())) count++;
		if (HasToiletPaper(array, pos.Down().Left())) count++;
		return count;
	}

	public override long GetSolution2()
    {
        var copy = ToiletPaper.Select(t => t.ToCharArray()).ToArray();

		var count = 0;
		List<Location> toRemove = [];
		do
		{
			toRemove.Clear();
			for (int i = 0; i < copy.Length; ++i)
			{
				for (int j = 0; j < copy[0].Length; ++j)
				{
					var location = new Location(i, j);
					if (!HasToiletPaper(copy, location))
						continue;
					int adjCount = CountAdjacent(copy, location);
					if (adjCount < 4)
					{
						count++;
						toRemove.Add(location);
					}
				}
			}
			foreach (var l in toRemove)
			{
				copy[l.Row][l.Col] = '.';
			}		
		} while (toRemove.Count > 0);
		
		return count;
	}
}
