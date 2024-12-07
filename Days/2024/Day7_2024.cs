using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day7_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<(long Result, List<long> Arguments)> Equations { get; } = [];

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

    public bool Eval(long test, long val, int index, List<long> equation)
    {
        if (test == val && index == equation.Count)
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
            return true;
        }
            
        if (Eval(test, val + equation[index], index + 1, equation))
        {
            return true;
        }
        return false;
    }

    public bool Eval2(long test, long val, int index, List<long> equation)
    {
        if (test == val && index == equation.Count)
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
            return true;

        if (Eval2(test, val + equation[index], index + 1, equation))
            return true;

        // ignore negatives
        var digits = equation[index] == 0
            ? 1
            : (long)Math.Log10(equation[index]) + 1;
        if (Eval2(test, val * (long)Math.Pow(10, digits) + equation[index], index + 1, equation)) 
            return true;

        return false;
    }

    public override long GetSolution1()
    {
        long sum = 0;
        foreach (var equation in Equations)
        {
            if (Eval(equation.Result, equation.Arguments[0], 1, equation.Arguments))
            {
                sum += equation.Result;
            }
        }
        return sum;
    }

    public override long GetSolution2()
    {
        long sum = 0;
        foreach (var equation in Equations)
        {
            if (Eval2(equation.Result, equation.Arguments[0], 1, equation.Arguments))
            {
                sum += equation.Result;
            }
        }
        return sum;
    }
}
