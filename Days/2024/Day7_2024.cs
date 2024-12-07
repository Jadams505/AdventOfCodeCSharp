using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day7_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<(long, List<long>)> Equations { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach(var line in contents)
        {
            var matches = Number().Matches(line);

            var test = long.Parse(matches.First().Value);
            var rest = matches.Skip(1).Select(m => long.Parse(m.Value)).ToList();
            Equations.Add((test, rest));
        }
    }

    public List<(Operation Opp, long Num)> SolveCache = [];

    public bool Eval(long test, long val, int index, List<long> equation)
    {
        if (test == val && index == equation.Count /*This was my bug*/)
        {
            return true;
        }
        if (index >= equation.Count)
        {
            return false;
        }
        if (val > test)
        {
            return false;
        }
        if (val < 0)
        {
            return false; // overflow
        }
           

        if (Eval(test, val * equation[index], index + 1, equation))
        {
            SolveCache.Add((Operation.Mult, equation[index]));
            return true;
        }
            
        if (Eval(test, val + equation[index], index + 1, equation))
        {
            SolveCache.Add((Operation.Add, equation[index]));
            return true;
        }
        return false;
    }

    public bool Eval2(long test, long val, int index, List<long> equation)
    {
        if (test == val && index == equation.Count /*This was my bug*/)
        {
            return true;
        }
        if (index >= equation.Count)
        {
            return false;
        }
        if (val > test)
        {
            return false;
        }
        if (val < 0)
        {
            return false; // overflow
        }


        if (Eval2(test, val * equation[index], index + 1, equation))
        {
            SolveCache.Add((Operation.Mult, equation[index]));
            return true;
        }

        if (Eval2(test, val + equation[index], index + 1, equation))
        {
            SolveCache.Add((Operation.Add, equation[index]));
            return true;
        }

        // super dumb way to concat, but whatever
        if (Eval2(test, long.Parse($"{val}{equation[index]}"), index + 1, equation))
        {
            SolveCache.Add((Operation.Concat, equation[index]));
            return true;
        }

        return false;
    }

    public enum Operation
    {
        Add,
        Mult,
        Concat,
        None
    };

    public List<List<(Operation Opp, long Num)>> Solutions = [];

    public long GetSolution(List<(Operation Opp, long Num)> solution)
    {
        long total = 0;
        foreach (var (Opp, Num) in solution)
        {
            if (Opp is Operation.None) total = Num;
            if (Opp is Operation.Add) total += Num;
            if (Opp is Operation.Mult) total *= Num;
        }
        return total;
    }

    public void PrintSolution(long answer, List<(Operation Opp, long Num)> solution)
    {
        Console.Write($"{answer} = ");
        foreach(var (Opp, Num) in solution)
        {
            if (Opp is Operation.None) Console.Write(Num);
            if (Opp is Operation.Add) Console.Write($" + {Num}");
            if (Opp is Operation.Mult) Console.Write($" * {Num}");
        }
        Console.WriteLine();
    }

    public override long GetSolution1()
    {
        long sum = 0;
        int count = 0;
        foreach (var equation in Equations)
        {
            count++;
            SolveCache = [];
            if (Eval(equation.Item1, equation.Item2[0], 1, equation.Item2))
            {
                SolveCache.Reverse(); // since the recursion is backwards
                sum += equation.Item1;
                var sol = SolveCache.Prepend((Operation.None, equation.Item2[0])).ToList();
                var answer = GetSolution(sol);
                //PrintSolution(equation.Item1, sol);
                Solutions.Add(sol);
            }
        }

        // 304936744902 too high
        // 303943215325 too high

        return sum;
    }

    public override long GetSolution2()
    {
        long sum = 0;
        int count = 0;
        foreach (var equation in Equations)
        {
            count++;
            SolveCache = [];
            if (Eval2(equation.Item1, equation.Item2[0], 1, equation.Item2))
            {
                SolveCache.Reverse(); // since the recursion is backwards
                sum += equation.Item1;
                var sol = SolveCache.Prepend((Operation.None, equation.Item2[0])).ToList();
                var answer = GetSolution(sol);
                if (sol.Count != equation.Item2.Count)
                {
                    int x = 3;
                }
                //PrintSolution(equation.Item1, sol);
                Solutions.Add(sol);
            }
        }

        // 1035826007640 too low
        // 2165139500917 too low

        return sum;
    }
}
