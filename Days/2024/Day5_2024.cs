using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day5_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<List<int>> Lists { get; } = [];

    public Dictionary<int, List<int>> Rules { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        var listRegex = new Regex(@"^(?:(\d+),)*(\d+)$");
        var ruleRegex = new Regex(@"^(\d+)\|(\d+)$");

        foreach(var line in contents)
        {

            var listMatch = listRegex.Match(line);

            if (listMatch.Success)
            {
                var list = new List<int>();
                foreach (var g in listMatch.Groups.Values.Skip(1))
                {
                    list.AddRange(g.Captures.Select(cap => int.Parse(cap.Value)));
                }
                Lists.Add(list);
                continue;
            }

            var ruleMatch = ruleRegex.Match(line);
            if (ruleMatch.Success)
            {
                var num1 = int.Parse(ruleMatch.Groups[1].Value);
                var num2 = int.Parse(ruleMatch.Groups[2].Value);

                if (Rules.TryGetValue(num1, out var list))
                {
                    list.Add(num2);
                }
                else
                {
                    Rules.Add(num1, [num2]);
                }
                continue;
            }
        }
    }

    public override long GetSolution1()
    {
        int sum = 0;
        foreach (var list in Lists)
        {
            var valid = CheckRules(list);
            if (valid)
            {
                sum += list[list.Count / 2];
            }
        }
        return sum;
    }

    private bool CheckRules(List<int> list)
    {
        var lookup = list.Index().ToDictionary(item => item.Item, item => item.Index);
        foreach (var (ourIndex, num) in list.Index())
        {
            // if there is no rule its valid
            if (!Rules.TryGetValue(num, out var rule)) return true;

            foreach (var after in rule)
            {
                // if both numbers are not in the list its valid
                if (!lookup.TryGetValue(after, out var afterIndex)) continue;

                if (ourIndex > afterIndex) return false;
            }
        }
        return true;
    }

    public class RuleComparer : IComparer<int>
    {
        public Dictionary<int, List<int>> Rules { get; set; } = [];

        public int Compare(int x, int y)
        {
            if (!Rules.TryGetValue(x, out var list)) return -1;
            if (list.Contains(y))
            {
                return -1;
            }

            return x == y ? 0 : 1;
        }
    }

    public override long GetSolution2()
    {
        int sum = 0;
        var comparer = new RuleComparer()
        {
            Rules = Rules
        };
        foreach (var list in Lists)
        {
            var valid = CheckRules(list);
            if (!valid)
            {
                var sorted = list.Order(comparer).ToList();
                sum += sorted[sorted.Count / 2];
            }
        }
        return sum;
    }
}
