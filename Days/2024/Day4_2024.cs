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

    public bool CheckXMAS(List<(int, int)> indexes)
    {
        var word = Convert(indexes);
        if (word is "XMAS" or "SAMX")
        {
            return true;
        }
        return false;
    }

    // Scans a 7x7 area looking for XMAS with startI and startJ as the center
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
            CheckXMAS(topLeft),
            CheckXMAS(top),
            CheckXMAS(topRight),
            CheckXMAS(bottomLeft),
            CheckXMAS(bottomRight),
            CheckXMAS(bottom),
            CheckXMAS(left),
            CheckXMAS(right)
        ];

        return checks.Count(c => c);
    }

    public bool CheckX_MAS(List<(int, int)> leftDiag, List<(int, int)> rightDiag)
    {
        var word = Convert(leftDiag);
        var word2 = Convert(rightDiag);
        if (word is "MAS" or "SAM" && word2 is "MAS" or "SAM")
        {
            return true;
        }
        return false;
    }

    // Scans a 3x3 area looking for X-MAS with startI and startJ as the center
    public bool CheckX_MAS(int startI, int startJ)
    {
        var len = 2;

        var leftDiag = new List<(int, int)>();
        var rightDiag = new List<(int, int)>();

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
                    if (i <= startI && j <= startJ ||
                        i >= startI && j >= startJ) 
                            leftDiag.Add(currIndex);

                    if (i <= startI && j >= startJ ||
                        i >= startI && j <= startJ) 
                            rightDiag.Add(currIndex);
                }
            }
        }

        return CheckX_MAS(leftDiag, rightDiag);
    }

    public override long GetSolution1()
    {
        var count = 0;
        for (int i = 0; i < Data.Count; ++i)
        {
            for(int j = 0; j < Data[i].Length; ++j)
            {
                // Only checking X as the origin eliminates overlap
                if (Data[i][j] == 'X')
                    count += CheckXMAS(i, j);
            }
        }
        return count;
    }

    public override long GetSolution2()
    {
        int count = 0;
        for (int i = 0; i < Data.Count; ++i)
        {
            for (int j = 0; j < Data[i].Length; ++j)
            {
                // Only checking A as the origin eliminates overlap
                if (Data[i][j] == 'A')
                    count += CheckX_MAS(i, j) ? 1 : 0;
            }
        }
        return count;
    }
}
