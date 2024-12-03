using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day3_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<(int, int)> Data { get; } = [];

    public List<(int, int)> Data2 { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach (var line in contents)
        {
            var regex = new Regex(@"mul\((\d+),(\d+)\)");
            var match = regex.Match(line);
            while(match.Success)
            {
                var num1 = match.Groups[1].Value;
                var num2 = match.Groups[2].Value;
                Data.Add((int.Parse(num1), int.Parse(num2)));
                match = match.NextMatch();
            } 
        }

        var input = "do()" + contents.Aggregate("", (total, next) => total + next);
        var dontSplit = input.Split("don't()");

        foreach (var dos in dontSplit)
        {
            var doIndex = dos.IndexOf("do()");
            if (doIndex == -1) continue;

            var regex = new Regex(@"mul\((\d+),(\d+)\)");
            var match = regex.Match(dos, doIndex);
            while (match.Success)
            {
                var num1 = match.Groups[1].Value;
                var num2 = match.Groups[2].Value;
                Data2.Add((int.Parse(num1), int.Parse(num2)));
                match = match.NextMatch();
            }
        }

    }

    public override long GetSolution1()
    {
        return Data.Aggregate(0, (total, curr) => total + curr.Item1 * curr.Item2);
    }

    public override long GetSolution2()
    {


        return Data2.Aggregate(0, (total, curr) => total + curr.Item1 * curr.Item2); ;
    }
}
