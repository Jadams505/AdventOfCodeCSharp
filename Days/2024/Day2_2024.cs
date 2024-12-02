using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day2_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<List<int>> Data { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach (var s in contents)
        {
            var row = s.Split(" ");
            var list = new List<int>();
            foreach (var c in row)
            {
                list.Add(int.Parse(c));
                
            }
            Data.Add(list);
        }
    }

    public override long GetSolution1()
    {
        return Data.Count(CheckSafeRow);
    }

    public static List<int> ComputeDiffs(List<int> row)
    {
        var diffs = new List<int>();
        for (int i = 0; i < row.Count - 1; ++i)
        {
            var curr = row[i];
            var next = row[i + 1];
            diffs.Add(next - curr);
        }

        return diffs;
    }

    public static bool CheckSafeDiffs(List<int> diffs)
    {
        bool increasing = diffs.All(num => num is 1 or 2 or 3);
        bool decreasing = diffs.All(num => num is -1 or -2 or -3);

        return increasing || decreasing;
    }


    public static bool CheckSafeRow(List<int> row)
    {
        var diffs = ComputeDiffs(row);

        return CheckSafeDiffs(diffs);
    }

    public static bool CheckSafeWithRemoval(List<int> row)
    {
        for (int i = 0; i < row.Count; ++i)
        {
            var copy = new List<int>(row);
            copy.RemoveAt(i);
            if (CheckSafeRow(copy)) return true;
        }

        return false;
    }

    public override long GetSolution2()
    {
        return Data.Count(CheckSafeWithRemoval);
    }
}
