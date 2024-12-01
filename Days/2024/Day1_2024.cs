using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day1_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<(int, int)> Data { get; } = [];

    public List<int> List1 { get; } = [];

    public List<int> List2 { get; } = [];

    public override void ConvertData()
    {
        string[] contents = File.ReadAllLines(SolutionFilePath);

        foreach (var s in contents)
        {
            var num1 = Number().Match(s);
            var num2 = num1.NextMatch();

            Data.Add((int.Parse(num1.Value), int.Parse(num2.Value)));

            List1.Add(int.Parse(num1.Value));
            List2.Add(int.Parse(num2.Value));
        }
    }

    public long GetOldSolution1()
    {
        var first = Data.Select(x => x.Item1).Order().ToList();
        var second = Data.Select(x => x.Item2).Order().ToList();

        var dist = first.Index().Join(second.Index(), first => first.Index, second => second.Index, (first, second) => Math.Abs(second.Item - first.Item));

        var sum = dist.Sum();

        return sum;
    }

    public override long GetSolution1()
    {
        var first = List1.Order();
        var second = List2.Order();

        var sum = first.Zip(second, (a, b) => Math.Abs(b - a)).Sum();

        return sum;
    }

    public long OneLinerSolution1() => Data.Select(x => x.Item1).Order().Index()
        .Join(
            inner: Data.Select(x => x.Item2).Order().Index(),
            outerKeySelector: first => first.Index, 
            innerKeySelector: second => second.Index, 
            resultSelector: (first, second) => Math.Abs(second.Item - first.Item))
        .Sum();

    public long OldSolution2()
    {
        var first = Data.Select(x => x.Item1).ToList();
        var second = Data.Select(x => x.Item2).ToList();

        var total = 0;

        foreach (var entry in first)
        {
            var x = entry * second.Count(e => e == entry);
            total += x;
        }

        return total;
    }

    public override long GetSolution2()
    {
        var countLookup = List2
            .GroupBy(num => num)
            .ToDictionary(
                keySelector: group => group.Key, 
                elementSelector: group => group.Count());

        var total = List1
            .Aggregate(0, (sum, entry) => 
                sum + entry * countLookup.GetValueOrDefault(entry, 0));

        //long sum = 0;
        //foreach(var entry in List1)
        //{
        //    var count = countLookup.GetValueOrDefault(entry, 0);
        //    var score = entry * count;
        //    sum += score;
        //}

        return total;
    }

    public long OneLinerSolution2() => Data.Select(x => x.Item1)
        .Aggregate(
        seed: 0, 
        func: (total, entry) => total + entry * Data.Select(x => x.Item2)
            .Count(e => e == entry));
}
