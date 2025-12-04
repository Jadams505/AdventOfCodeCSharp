using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2025;

internal class Day3_2025 : Day2025
{
    public override Regex ParseString { get; }

    public List<string> Batteries { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);
        foreach (var c in contents)
        {
            Batteries.Add(c);
        }
    }

    public override long GetSolution1()
    {
        long sum = 0;

        foreach (var b in Batteries)
        {
            var largest = char.GetNumericValue(b[0]);
            int largestIndex = 0;
            for (int i = 1; i < b.Length - 1; ++i)
            {
                if (char.GetNumericValue(b[i]) > largest)
                {
                    largest = char.GetNumericValue(b[i]);
                    largestIndex = i;
                }
            }

            var largest2 = char.GetNumericValue(b[largestIndex + 1]);
            var largestIndex2 = largestIndex + 1;
            for (int i = largestIndex + 2; i < b.Length; ++i)
            {
                if (char.GetNumericValue(b[i]) > largest2)
                {
                    largest2 = char.GetNumericValue(b[i]);
                    largestIndex2 = i;
                }
            }

            sum += 10 * (int)largest + (int)largest2;
        }

        return sum;
    }

    public long Joltage(string battery, int start, int length)
    {
        if (length == 0) 
            return 0;
        if (start >= battery.Length) 
            return 0; // shouldn't happen

        var end = battery.Length - length + 1; // why +1
        var slice = battery.AsSpan().Slice(start, end - start);

        int largest = (int)char.GetNumericValue(slice[0]);
        int largestIndex = 0;
        for (int i = 1; i < slice.Length; ++i)
        {
            if (char.GetNumericValue(slice[i]) > largest)
            {
                largest = (int)char.GetNumericValue(slice[i]);
                largestIndex = i;
            }
        }

        long total = (long)Math.Pow(10, length - 1) * largest;
        return total + Joltage(battery, start +largestIndex + 1, length - 1);
    }

    public override long GetSolution2()
    {
        long sum = 0;
        foreach (var battery in Batteries)
        {
            sum += Joltage(battery, 0, 12);
        }
        return sum;
    }
}
