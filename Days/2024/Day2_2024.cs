using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day2_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<List<int>> Data { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach (var s in contents)
        {
            var row = s.Split(" ");
            var list = new List<int>();
            foreach (var c in row)
            {
                list.Add(int.Parse(c));
                
            }
            Data.Add(list);
        }
    }

    public override long GetSolution1()
    {
        int safes = 0;
        foreach (var row in Data)
        {
            int curr = row[0];
            int next = row[1];

            bool? decreasing = null;
            bool? increasing = null;
            bool safe = true;
            for (int i = 1; i < row.Count; ++i)
            {
                next = row[i];
                
                if (next > curr)
                {
                    increasing = true;
                }
                else if (next < curr)
                {
                    decreasing = true;
                }
                else
                {
                    safe = false;
                    break;
                }

                if (decreasing is true && increasing is true)
                {
                    safe = false;
                    break;
                }

                if (!(Math.Abs(curr - next) >= 1 && Math.Abs(curr - next) <= 3))
                {
                    safe = false;
                    break;
                }
                curr = next;
            }

            if (safe)
            {
                safes++;
            }
        }
        return safes;
    }

    public static bool IsSafe(List<int> row)
    {
        int curr = row[0];
        int next = row[1];

        bool? decreasing = null;
        bool? increasing = null;
        bool safe = true;
        for (int i = 1; i < row.Count; ++i)
        {
            next = row[i];

            if (next > curr)
            {
                increasing = true;
            }
            else if (next < curr)
            {
                decreasing = true;
            }
            else
            {
                safe = false;
                break;
            }

            if (decreasing is true && increasing is true)
            {
                safe = false;
                break;
            }

            if (!(Math.Abs(curr - next) >= 1 && Math.Abs(curr - next) <= 3))
            {
                safe = false;
                break;
            }
            curr = next;
        }

        return safe;
    }

    public override long GetSolution2()
    {

        int safes = 0;
        List<List<int>> Unsafe = [];
        foreach (var row in Data)
        {
            bool safe = IsSafe(row);
            if (safe)
            {
                safes++;
            }
            else
            {
                Unsafe.Add(row);
            }
        }

        foreach(var row in Unsafe)
        {
            
            for (int i = 0; i < row.Count; ++i)
            {
                var temp = new List<int>(row);
                temp.RemoveAt(i);
                bool safe = IsSafe(temp);
                if (safe)
                {
                    safes++;
                    break;
                }
            }
        }


        return safes;
    }
}
