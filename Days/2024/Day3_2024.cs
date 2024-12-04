using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day3_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<(int, int)> MulData { get; } = [];

    public List<(int, int)> DoMulData { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllText(SolutionFilePath);

        var mulRegex = new Regex(@"mul\((\d+),(\d+)\)");
        {
            var match = mulRegex.Match(contents);
            while (match.Success)
            {
                var num1 = match.Groups[1].Value;
                var num2 = match.Groups[2].Value;
                MulData.Add((int.Parse(num1), int.Parse(num2)));
                match = match.NextMatch();
            }
        }

        // Adding the do() is a hack to avoid edge cases
        var dontSplit = $"do(){contents}".Split("don't()");

        foreach (var dos in dontSplit)
        {
            var doIndex = dos.IndexOf("do()");
            if (doIndex == -1) continue;

            // match everything after a do(), but before the next don't()
            var match = mulRegex.Match(dos, doIndex);
            while (match.Success)
            {
                var num1 = match.Groups[1].Value;
                var num2 = match.Groups[2].Value;
                DoMulData.Add((int.Parse(num1), int.Parse(num2)));
                match = match.NextMatch();
            }
        }

    }

    public override long GetSolution1()
    {
        return MulData.Aggregate(0, (total, curr) => total + curr.Item1 * curr.Item2);
    }

    public override long GetSolution2()
    {
        return DoMulData.Aggregate(0, (total, curr) => total + curr.Item1 * curr.Item2); ;
    }
}
