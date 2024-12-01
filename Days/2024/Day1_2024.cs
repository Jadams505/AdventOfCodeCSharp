using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day1_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<string> Contents { get; } = [];

    public List<int> Numbers { get; } = [];

    public List<(int, int)> Data { get; } = [];

    public override void ConvertData()
    {
        string[] contents = File.ReadAllLines(SolutionFilePath);

        Contents.AddRange(contents);
        try
        {
            Numbers.AddRange(contents.Select(entry => int.Parse(Number().Match(entry).Value)));
        }
        catch(Exception ex)
        {
            Console.WriteLine
            (
                $"""
                Failed to convert input to numbers with message:
                {ex.Message}
                """
            );
        }

        foreach (var s in contents)
        {
            var num1 = Number().Match(s);
            var num2 = num1.NextMatch();

            Data.Add((int.Parse(num1.Value), int.Parse(num2.Value)));
        }
    }

    public override long GetSolution1()
    {
        long ret = 0;

        var first = Data.Select(x => x.Item1).Order().ToList();
        var second = Data.Select(x => x.Item2).Order().ToList();

        var dist = first.Index().Join(second.Index(), first => first.Index, second => second.Index, (first, second) => Math.Abs(second.Item - first.Item));

        var sum = dist.Sum();

        return OneLinerSolution1();
    }

    public long OneLinerSolution1() => Data.Select(x => x.Item1).Order().Index()
        .Join(
            inner: Data.Select(x => x.Item2).Order().Index(),
            outerKeySelector: first => first.Index, 
            innerKeySelector: second => second.Index, 
            resultSelector: (first, second) => Math.Abs(second.Item - first.Item))
        .Sum();

    public override long GetSolution2()
    {
        long ret = 0;

        var first = Data.Select(x => x.Item1).ToList();
        var second = Data.Select(x => x.Item2).ToList();

        var total = 0;

        foreach (var entry in first)
        {
            var x = entry * second.Count(e => e == entry);
            total += x;
        }

        var dist = first.Aggregate(0, (total, entry) => total + entry * second.Count(e => e == entry));

        List<int> test = [1, 2, 3, 2, -1];
        var sum = test.Aggregate(0, (total, curr) => total + (curr * 3));

        return OneLinerSolution2();
    }

    public long OneLinerSolution2() => Data.Select(x => x.Item1)
        .Aggregate(
        seed: 0, 
        func: (total, entry) => total + entry * Data.Select(x => x.Item2)
            .Count(e => e == entry));
}
