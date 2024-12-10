using AdventOfCode.Util;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2024;

internal class Day9_2024 : Day2024
{
    public override Regex ParseString => throw new NotImplementedException();

    public List<Disk> Data { get; } = [];

    public override void ConvertData()
    {
        var contents = File.ReadAllLines(SolutionFilePath);

        foreach (var line in contents)
        {
            for (int i = 0; i < line.Length - 1; i += 2)
            {
                var size = line[i];
                var gap = line[i + 1];
                Data.Add(new Disk(size, i));
                Data.Add(new Disk(size, -1));
            }
        }
    }

    private string? _memoryCache;
    public string Memory
    {
        get
        {
            if (_memoryCache is null)
            {
                var builder = new StringBuilder();
                foreach (var disk in Data)
                {
                    builder.Append(disk.ToString());
                }
                _memoryCache = builder.ToString();
            }

            return _memoryCache;
        }
    }

    public override long GetSolution1()
    {
        var head = 0;
        var tail = Data.Count - 1;
        while(head < tail)
        {
            var first = Data[head];
            var last = Data[tail];
            if (first.Id != -1)
            {
                head++;
                continue;
            }

            if (last.Id == -1)
            {
                tail--;
                continue;
            }

            first.FillGap(last);
            if (first.Empty)
            {
                Data.RemoveAt(head);
                tail--;
            }

            if (!last.Empty && last.Id != -1)
            {
                Data.RemoveAt(tail);
                Data.Insert(head, last);
            }
        }
        
        return 0;
    }

    public long CheckSum(char[] memory)
    {
        long sum = 0;
        for (int i = 0; i < memory.Length && memory[i] != '.'; ++i)
        {
            var value = (int)char.GetNumericValue(memory[i]);
            sum += value * i;
        }
        return sum;
    }

   
    public override long GetSolution2()
    {
        return 0;
    }
}
public class Disk : Space
{
    public int Id { get; set; }

    public const int GapId = -1;

    public Disk(int size, int id)
    {
        if (id < 0) id = GapId;

        Size = size;
        Id = id;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        var block = Id.ToString();
        for (int i = 0; i < Size; ++i)
        {
            builder.Append(block);
        }
        return builder.ToString();
    }
}

public class Gap : Space
{
    public Gap(int size)
    {
        Size = size;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        var block = '.';
        for (int i = 0; i < Size; ++i)
        {
            builder.Append(block);
        }
        return builder.ToString();
    }
}
public abstract class Space
{
    public int Size { get; set; }

    public bool Empty => Size == 0;
}

public static class Day9Extensions
{
    public static void ExpandGap(this Gap gap, Gap other)
    {
        gap.Size += other.Size;
    }

    public static bool FillGap(this Disk gap, Disk disk)
    {
        if (gap.Id == -1)
        {
            var mergeSpace = gap.Size - disk.Size;
            gap.Size = Math.Clamp(disk.Size, 0, gap.Size);
            disk.Size = Math.Abs(mergeSpace);
            gap.Id = disk.Id;
            return gap.Size == 0;
        }

        return false;
    }
}
