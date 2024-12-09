using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using Location = (int Row, int Col);

namespace AdventOfCode.Days._2024;

internal class Day8_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<string> Map { get; } = [];
    public Dictionary<char, List<Location>> FrequencyLookup = [];
    public Dictionary<Location, HashSet<int>> Antinodes = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach(var line in contents.Index())
        {
            Map.Add(line.Item);
        }

        for (int i = 0; i < Map.Count; ++i)
        {
            for (int j = 0; j < Map[i].Length; ++j)
            {
                var c = Map[i][j];
                if (c == '.' || c == '#') continue;
                if (FrequencyLookup.TryGetValue(c, out var list))
                {
                    list.Add((i, j));
                }
                else
                {
                    FrequencyLookup[c] = [(i, j)];
                }
            }
        }
    }

    public bool ValidPoint(int row, int col)
    {
        return row >= 0 && row < Map.Count && col >= 0 && col < Map[row].Length; 
    }

    public bool ValidPoint(Location pos) => ValidPoint(pos.Row, pos.Col);

    public char Get(Location pos) => Map[pos.Row][pos.Col];

    public bool AddAntinode(char val, Location pos)
    {
        if (!ValidPoint(pos)) return false;

        if (Antinodes.TryGetValue(pos, out var set))
        {
            return set.Add(val);
        }
        else
        {
            Antinodes[pos] = [val];
            return true;
        }
    }

    public void AddAntinode(Location a, Location b)
    {
        var delta = a.Delta(b);

        var left = a.Minus(delta);
        var right = b.Plus(delta);

        AddAntinode(Get(a), left);
        AddAntinode(Get(a), right);
    }

    public override long GetSolution1()
    {
        //long sum = 0;

        //foreach(var frequencies in FrequencyLookup)
        //{
        //    for (int i = 0; i < frequencies.Value.Count; ++i)
        //    {
        //        for (int j = i + 1; j < frequencies.Value.Count; ++j)
        //        {
        //            var a = frequencies.Value[i];
        //            var b = frequencies.Value[j];

        //            AddAntinode(a, b);
        //        }
        //    }
        //}

        return Antinodes.Count;
    }

    public void AddAntinode2(Location a, Location b)
    {
        var delta = a.Delta(b);
        AddAntinode(Get(a), a);
        AddAntinode(Get(b), b);
        var left = a.Minus(delta);
        var right = b.Plus(delta);
        for (int i = 0; i < 100; ++i)
        {
            AddAntinode(Get(a), left);
            AddAntinode(Get(a), right);

            left = left.Minus(delta);
            right = right.Plus(delta);
        }
    }

    public override long GetSolution2()
    {
        foreach (var frequencies in FrequencyLookup)
        {
            for (int i = 0; i < frequencies.Value.Count; ++i)
            {
                for (int j = i + 1; j < frequencies.Value.Count; ++j)
                {
                    var a = frequencies.Value[i];
                    var b = frequencies.Value[j];

                    AddAntinode2(a, b);
                }
            }
        }

        return Antinodes.Count;
    }
}

public static class Extensions2D
{
    public static Location Up(this Location pos, int n = 1) => (pos.Row - n, pos.Col);
    public static Location Down(this Location pos, int n = 1) => (pos.Row + n, pos.Col);
    public static Location Left(this Location pos, int n = 1) => (pos.Row, pos.Col - n);
    public static Location Right(this Location pos, int n = 1) => (pos.Row, pos.Col + n);

    public static Location DeltaAbs(this Location pos, Location to) => 
        (Math.Abs(pos.Row - to.Row), Math.Abs(pos.Col - to.Col));

    public static Location Delta(this Location pos, Location to) =>
        (to.Row - pos.Row, to.Col - pos.Col);

    public static Location Plus(this Location pos, Location other) =>
        (pos.Row + other.Row, pos.Col + other.Col);

    public static Location Minus(this Location pos, Location other) =>
        (pos.Row - other.Row, pos.Col - other.Col);


}
