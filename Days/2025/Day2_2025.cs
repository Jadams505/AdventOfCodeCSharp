using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2025;

using IdRange = (long Start, long End);

internal class Day2_2025 : Day2025
{
    public override Regex ParseString { get; }

    public List<IdRange> Ranges { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllText(SolutionFilePath);
        var ranges = contents.Trim().Split(',');
        foreach (var r in ranges)
        {
            var nums = r.Split('-');
            Ranges.Add((long.Parse(nums[0]), long.Parse(nums[1])));
        }
    }

    public IEnumerable<long> CountInvalidIds(IdRange range)
    {
        for (long i = range.Start; i <= range.End; ++i)
        {
            var stringNum = i.ToString().AsSpan();
            if (stringNum.Length % 2 != 0) continue;
            int middle = stringNum.Length / 2;
            var firstHalf = stringNum[..middle];
            var lastHalf = stringNum[middle..];
            if (firstHalf.SequenceEqual(lastHalf))
                yield return i;
        }
    }

	public IEnumerable<long> CountInvalidIds2(IdRange range)
	{
		for (long i = range.Start; i <= range.End; ++i)
		{
			var stringNum = i.ToString();
			
            for (int index = 1; index <= stringNum.Length; ++index)
            {
                var repeat = stringNum.AsSpan().Slice(0, index);
                if (CheckRepeat(stringNum, repeat))
                {
                    yield return i;
                    goto End; // I hate this
                }
            }
            End:;
		}
	}

    public bool CheckRepeat(ReadOnlySpan<char> original, ReadOnlySpan<char> repeat)
    {
        if (original.Length % repeat.Length != 0) return false;
        if (original.Length == repeat.Length) return false;
        int times = original.Length / repeat.Length;

        for (int i = 0; i <= times - 1; ++i)
        {
            int index = i * repeat.Length;
            if (!original.Slice(index, repeat.Length).SequenceEqual(repeat))
                return false;
        }
        return true;
    }

	public static int DigitCount(long num)
    {
        // lazy solution
        return num.ToString().Length;
    }

    public override long GetSolution1()
    {
        var count = 0L;
        foreach (var range in Ranges)
        {
            count += CountInvalidIds(range).Sum();
        }
        return count;
    }

    public override long GetSolution2()
    {
        var count = 0L;
        foreach (var range in Ranges)
        {
            count += CountInvalidIds2(range).Sum();
        }
        return count;
    }
}
