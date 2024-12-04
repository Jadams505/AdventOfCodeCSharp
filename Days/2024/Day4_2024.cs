using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day4_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<string> Data { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach(var line in contents)
        {
            Data.Add(line);
        }
    }

    public string Convert(List<(int, int)> indexes)
    {
        var builder = new StringBuilder();
        foreach(var i in indexes)
        {
            builder.Append(Data[i.Item1][i.Item2]);
        }
        return builder.ToString();
    }

    public string Flatten(List<(int, int)> indexes)
    {
        var builder = new StringBuilder();

        foreach(var i in indexes)
        {
            builder.Append(i.Item1);
            builder.Append(i.Item2);
        }

        return builder.ToString();
    }

    public List<HashSet<(int, int)>> Found { get; } = [];
    public bool CheckAndCache(List<(int, int)> indexes)
    {
        var word = Convert(indexes);
        if (word is "XMAS" or "SAMX")
        {
            var set = indexes.ToHashSet();
            var contains = Found.Contains(set, new SetEqualityComparer<(int, int)>());
            if (contains) return false;

            Found.Add(set);
            return true;
        }
        return false;
    }

    public class SetEqualityComparer<T> : IEqualityComparer<HashSet<T>>
    {
        public bool Equals(HashSet<T>? x, HashSet<T>? y)
        {
            if (x is null) return false;
            if (y is null) return false;
            return x.SetEquals(y);
        }

        public int GetHashCode([DisallowNull] HashSet<T> obj)
        {
            return obj.GetHashCode();
        }
    }


    public int CheckXMAS(int startI, int startJ)
    {
        var len = 4;

        var topLeft = new List<(int, int)>();
        var top = new List<(int, int)>();
        var topRight = new List<(int, int)>();
        var bottomLeft = new List<(int, int)>();
        var bottomRight = new List<(int, int)>();
        var bottom = new List<(int, int)>();
        var left = new List<(int, int)>();
        var right = new List<(int, int)>();

        for (int i = startI - len + 1; i < startI + len; ++i)
        {
            for (int j = startJ - len + 1; j < startJ + len; ++j)
            {
                if (i < 0 || i >= Data.Count) continue;
                if (j < 0 || j >= Data[i].Length) continue;

                //if (i == startI && j == startJ) continue;

                var curr = Data[i][j];
                var currIndex = (i, j);
                if (Math.Abs(startI - i) == Math.Abs(startJ - j))
                {
                    if (i <= startI && j <= startJ) topLeft.Add(currIndex);
                    if (i <= startI && j >= startJ) topRight.Add(currIndex);
                    if (i >= startI && j >= startJ) bottomRight.Add(currIndex);
                    if (i >= startI && j <= startJ) bottomLeft.Add(currIndex);
                }

                if (i == startI)
                {
                    if (j <= startJ) left.Add(currIndex);
                    if (j >= startJ) right.Add(currIndex);
                }

                if (j == startJ)
                {
                    if (i <= startI) top.Add(currIndex);
                    if (i >= startI) bottom.Add(currIndex);
                }
            }
        }

        List<bool> checks = 
        [
            CheckAndCache(topLeft),
            CheckAndCache(top),
            CheckAndCache(topRight),
            CheckAndCache(bottomLeft),
            CheckAndCache(bottomRight),
            CheckAndCache(bottom),
            CheckAndCache(left),
            CheckAndCache(right)
        ];

        return checks.Count(c => c);
    }

    public List<HashSet<(int, int)>> Found2 { get; } = [];
    public bool CheckAndCache2(List<(int, int)> leftDiag, List<(int, int)> rightDiag)
    {
        var word = Convert(leftDiag);
        var word2 = Convert(rightDiag);
        if (word is "MAS" or "SAM" && word2 is "MAS" or "SAM")
        {
            var set = leftDiag.Concat(rightDiag).ToHashSet();
            var contains = Found2.Contains(set, new SetEqualityComparer<(int, int)>());
            if (contains) return false;

            Found2.Add(set);
            return true;
        }
        return false;
    }

    public int CheckX_MAS(int startI, int startJ)
    {
        var len = 2;

        var topLeft = new List<(int, int)>();
        var topRight = new List<(int, int)>();
        var bottomLeft = new List<(int, int)>();
        var bottomRight = new List<(int, int)>();

        for (int i = startI - len + 1; i < startI + len; ++i)
        {
            for (int j = startJ - len + 1; j < startJ + len; ++j)
            {
                if (i < 0 || i >= Data.Count) continue;
                if (j < 0 || j >= Data[i].Length) continue;

                var curr = Data[i][j];
                var currIndex = (i, j);
                if (Math.Abs(startI - i) == Math.Abs(startJ - j))
                {
                    if (i <= startI && j <= startJ) topLeft.Add(currIndex);
                    if (i <= startI && j >= startJ) topRight.Add(currIndex);
                    if (i >= startI && j >= startJ) bottomRight.Add(currIndex);
                    if (i >= startI && j <= startJ) bottomLeft.Add(currIndex);
                }
            }
        }

        var leftDiag = topLeft.Concat(bottomRight).Distinct();
        var rightDiag = topRight.Concat(bottomLeft).Distinct();

        return CheckAndCache2(leftDiag.ToList(), rightDiag.ToList()) ? 1 : 0;
    }

    public override long GetSolution1()
    {
        var count = 0;
        for (int i = 0; i < Data.Count; ++i)
        {
            for(int j = 0; j < Data[i].Length; ++j)
            {
                var x = CheckXMAS(i, j);
            }
        }
        return Found.Count;
    }

    public override long GetSolution2()
    {
        CheckX_MAS(1, 2);
        for (int i = 0; i < Data.Count; ++i)
        {
            for (int j = 0; j < Data[i].Length; ++j)
            {
                var x = CheckX_MAS(i, j);
            }
        }
        return Found2.Count;
    }
}
