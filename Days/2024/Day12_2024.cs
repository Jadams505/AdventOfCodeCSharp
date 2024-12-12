using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days._2024;
internal class Day12_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<string> Garden { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);
        foreach (var line in contents)
        {
            Garden.Add(line);
        }
    }

    public bool IsValid(Location pos) =>
        pos.InBounds(Garden.Count, Garden[0].Length);

    public char Get(Location pos) => Garden[pos.Row][pos.Col];

    public void FillGarden(Location start, Location next, HashSet<Location> found)
    {
        if (!IsValid(start))
            return;

        if (!IsValid(next))
            return;

        if (Get(start) != Get(next))
            return;

        if (found.Contains(next))
            return;
        else
            found.Add(next);

        FillGarden(next, next.Up(), found);
        FillGarden(next, next.Down(), found);
        FillGarden(next, next.Right(), found);
        FillGarden(next, next.Left(), found);
    }

    public HashSet<Location> GetGarden(Location start)
    {
        HashSet<Location> found = [start];
        FillGarden(start, start.Up(), found);
        FillGarden(start, start.Down(), found);
        FillGarden(start, start.Right(), found);
        FillGarden(start, start.Left(), found);

        return found;
    }

    public long GetPerimeter(HashSet<Location> garden)
    {
        long sum = 0;
        foreach (var pos in garden)
        {
            if (!garden.Contains(pos.Up()))
                sum++;
            if (!garden.Contains(pos.Down()))
                sum++;
            if (!garden.Contains(pos.Left()))
                sum++;
            if (!garden.Contains(pos.Right()))
                sum++;
        }
        return sum;
    }

    public long GetSides(HashSet<Location> garden)
    {
        long sum = 0;
        var sorted = garden.OrderBy(loc => loc.Row).ThenBy(loc => loc.Col).ToList();

        var ups = 0;
        var downs = 0;
        for (int i = 0; i < sorted.Count; ++i)
        {
            var curr = sorted[i];
            if (!garden.Contains(curr.Up()))
                ups++;
            else
            {
                sum += ups > 0 ? 1 : 0;
                ups = 0;
            }
            if (!garden.Contains(curr.Down()))
                downs++;
            else
            {
                sum += downs > 0 ? 1 : 0;
                downs = 0;
            }
            if (i != sorted.Count - 1)
            {
                var next = sorted[i + 1];
                if (curr.DirectionTo(next) is not Direction.East)
                {
                    sum += ups > 0 ? 1 : 0;
                    sum += downs > 0 ? 1 : 0;
                    ups = 0;
                    downs = 0;
                }
                else if (curr.DeltaAbs(next).Col > 1)
                {
                    sum += ups > 0 ? 1 : 0;
                    sum += downs > 0 ? 1 : 0;
                    ups = 0;
                    downs = 0;
                }
            }
        }
        sum += ups > 0 ? 1 : 0;
        sum += downs > 0 ? 1 : 0;

        sorted = garden.OrderBy(loc => loc.Col).ThenBy(loc => loc.Row).ToList();

        var rights = 0;
        var lefts = 0;
        for (int i = 0; i < sorted.Count; ++i)
        {
            var curr = sorted[i];
            if (!garden.Contains(curr.Right()))
                rights++;
            else
            {
                sum += rights > 0 ? 1 : 0;
                rights = 0;
            }
            if (!garden.Contains(curr.Left()))
                lefts++;
            else
            {
                sum += lefts > 0 ? 1 : 0;
                lefts = 0;
            }
            if (i != sorted.Count - 1)
            {
                var next = sorted[i + 1];
                if (curr.DirectionTo(next) is not Direction.South)
                {
                    
                    sum += rights > 0 ? 1 : 0;
                    sum += lefts > 0 ? 1 : 0;
                    rights = 0;
                    lefts = 0;
                }
                else if (curr.DeltaAbs(next).Row > 1)
                {
                    sum += rights > 0 ? 1 : 0;
                    sum += lefts > 0 ? 1 : 0;
                    rights = 0;
                    lefts = 0;
                }
            }
        }
        sum += rights > 0 ? 1 : 0;
        sum += lefts > 0 ? 1 : 0;

        return sum;
    }

    public void test()
    {
        
    }

    public override long GetSolution1()
    {
        var totalGarden = new HashSet<Location>();
        long total = 0;
        for (int i = 0; i < Garden.Count; ++i)
        {
            for (int j = 0; j < Garden[i].Length; ++j)
            {
                if (totalGarden.Contains((i, j)))
                    continue;
                var garden = GetGarden((i, j));
                foreach (var item in garden)
                {
                    totalGarden.Add(item);
                }
                total += GetPerimeter(garden) * garden.Count;
            }
        }
        return total;
    }

    public override long GetSolution2()
    {
        var totalGarden = new HashSet<Location>();
        long total = 0;
        for (int i = 0; i < Garden.Count; ++i)
        {
            for (int j = 0; j < Garden[i].Length; ++j)
            {
                if (totalGarden.Contains((i, j)))
                    continue;
                var garden = GetGarden((i, j));
                foreach (var item in garden)
                {
                    totalGarden.Add(item);
                }
                total += GetSides(garden) * garden.Count;
            }
        }
        return total;
    }
}
