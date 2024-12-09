using AdventOfCode.Util;
using System.Text.RegularExpressions;

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
                if (c == '.') continue;
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
        Antinodes.Clear();
        foreach (var frequencies in FrequencyLookup)
        {
            for (int i = 0; i < frequencies.Value.Count; ++i)
            {
                for (int j = i + 1; j < frequencies.Value.Count; ++j)
                {
                    var a = frequencies.Value[i];
                    var b = frequencies.Value[j];

                    AddAntinode(a, b);
                }
            }
        }

        return Antinodes.Count;
    }

    public bool AddAntinode2(char val, Location pos)
    {
        if (!ValidPoint(pos)) return false;

        if (Antinodes.TryGetValue(pos, out var set))
        {
            set.Add(val);
        }
        else
        {
            Antinodes[pos] = [val];
        }

        return true;
    }

    public void AddAntinode2(Location a, Location b)
    {
        var delta = a.Delta(b);
        var c = Get(a);

        var left = a;
        while(AddAntinode2(c, left))
        {
            left = left.Minus(delta);
        }

        var right = b;
        while (AddAntinode2(c, right))
        {
            right = right.Plus(delta);
        }
    }

    public override long GetSolution2()
    {
        Antinodes.Clear();
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
