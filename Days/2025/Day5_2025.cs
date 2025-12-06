using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using IdRange = (long First, long Second);

namespace AdventOfCode.Days._2025;

internal class Day5_2025 : Day2025
{
    public override Regex ParseString { get; } = new(@"^(?:(\d+)-(\d+))$");

    public List<IdRange> Ranges { get; } = [];
    public List<long> Ids { get; } = [];

    public override void ConvertData()
    {
        var c = File.ReadAllLines(SolutionFilePath);

        foreach (var line in c)
        {
            var match = ParseString.Match(line);
            if (match.Success)
            {
                var group = match.Groups;
                long first = long.Parse(group[1].Value);
                long second = long.Parse(group[2].Value);
                Ranges.Add((first, second));
            }
            else
            {
                var match2 = Number().Match(line);
                if (match2.Success)
                {
                    long id = long.Parse(match2.Value);
                    Ids.Add(id);
                }
            }
        }

    }

    public int CountFresh()
    {
        int count = 0;
        foreach (var id in Ids)
        {
            foreach (var range in Ranges)
            {
                if (id >= range.First && id <= range.Second)
                {
                    count++;
                    break;
                }

            }

        }
        return count;
    }

    public override long GetSolution1()
    {
        return CountFresh();
    }

    public override long GetSolution2()
    {
        var sorted = Ranges.OrderBy(r => r.First);
        List<IdRange> minimal = [sorted.First()];

        foreach (var range in sorted.Skip(1))
        {
            var best = minimal[^1];
            if (range.First > best.Second)
            {
                minimal.Add(range);
            }
            else // combine
            {
                best.First = Math.Min(range.First, best.First);
                best.Second = Math.Max(range.Second, best.Second);
                minimal[^1] = best;
            }
        }

        long count = 0;
        foreach (var range in minimal)
        {
            count += range.Second - range.First + 1;
        }
        return count;
    }
}
