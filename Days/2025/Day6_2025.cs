using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2025;

internal class Day6_2025 : Day2025
{
    public override Regex ParseString { get; }

    public Regex OperatorRegex = new(@"[*|+]");

    public List<List<int>> HorzontalNumbers { get; } = [];
    public List<List<int>> VerticalNumbers { get; } = [];

    public List<char> Operators { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);
        foreach (var c in contents.SkipLast(1))
        {
            var matches = Number().Matches(c);
            HorzontalNumbers.Add(matches.Select(m => int.Parse(m.Value)).ToList());
        }

        var num = new char[contents.Length - 1].AsSpan();
        List<int> currCol = [];
        for (int i = contents[0].Length - 1; i >= 0; --i)
        {
            int index = 0;
            int emptyCount = 0;
            foreach (var c in contents.SkipLast(1))
            {
                var curr = c[i];
                bool empty = curr == ' ';
                if (empty)
                    emptyCount++;
                num[index++] = empty ? '@' : curr;
            }
            if (emptyCount == num.Length)
            {
                VerticalNumbers.Add(currCol);
                currCol = [];
			}
            else
            {
                var realNum = int.Parse(num.Trim('@'));
                currCol.Add(realNum);
            }
        }
        if (currCol.Count > 0)
        {
            VerticalNumbers.Add(currCol);
        }
        foreach (var c in contents.TakeLast(1))
        {
            var matches = OperatorRegex.Matches(c);
            Operators.AddRange(matches.Select(m => m.Value[0]));
        }
    }

    public long CombineColumn(int column)
    {
        var @operator = Operators[column];
        long total = HorzontalNumbers[0][column];

        for (int i = 1; i < HorzontalNumbers.Count; ++i)
        {
            if (@operator == '*')
                total *= HorzontalNumbers[i][column];
            else if (@operator == '+')
                total += HorzontalNumbers[i][column];
        }
        return total;
    }

    public override long GetSolution1()
    {
        long total = 0;
        for (int i = 0; i < HorzontalNumbers[0].Count; ++i)
        {
            total += CombineColumn(i);
        }
        return total;
    }



	public long CombineColumn2(int column, List<char> ops)
	{
		var @operator = ops[column];
		long total = VerticalNumbers[column][0];

		for (int i = 1; i < VerticalNumbers[column].Count; ++i)
		{
			if (@operator == '*')
				total *= VerticalNumbers[column][i];
			else if (@operator == '+')
				total += VerticalNumbers[column][i];
		}
		return total;
	}



	public override long GetSolution2()
    {
		long total = 0;
		for (int i = 0; i < VerticalNumbers.Count; ++i)
		{
			total += CombineColumn2(i, Operators.Reverse<char>().ToList());
		}
		return total;
	}
}
