using AdventOfCode.Util;
using System.Collections.Immutable;
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
            for (int i = 0; i < line.Length; i += 2)
            {
                
                var size = (int)char.GetNumericValue(line[i]);
                Data.Add(new Disk(size, i / 2));
                if (i + 1 < line.Length)
                {
                    var gap = (int)char.GetNumericValue(line[i + 1]);

                    Data.Add(new Disk(gap, -1));
                }
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
        return 0;
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

            var fill = first.FillGap(last);
            if (fill > 0)
            {
                head++;
                Data.Insert(head, new Disk(fill, -1));
            }
            if (last.Empty)
            {
                Data.RemoveAt(tail);
                tail--;
            }
            else if (first.Id == last.Id)
            {
                head++;
            }
        }
        long total = 0;
        int index = 0;
        foreach (var disk in Data)
        {
            if (disk.Id == -1) break;

            var sum = disk.CheckSum(index);
            index += disk.Size;
            total += sum;
        }
        
        return total;
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
        var head = 0;
        var tail = Data.Count - 1;
        while (head < tail)
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

            var newTail = tail;
            while(head < newTail)
            {
                var newLast = Data[newTail];
                if (newLast.Id == -1)
                {
                    newTail--;
                    continue;
                }
                var canFill = first.CanFillGap(newLast);
                if (canFill)
                {
                    var fill = first.SwapGap(newLast);
                    newLast.Id = -1;
                    if (fill > 0)
                    {
                        head++;
                        Data.Insert(head, new Disk(fill, -1));
                    }
                    break;
                }
                else
                {
                    newTail--;
                }
            }

            

            static (int Head, int Tail) FillGap(List<Disk> Data, int head, int tail)
            {
                var first = Data[head];
                var last = Data[tail];
                var fill = first.FillGap(last);
                if (fill > 0)
                {
                    head++;
                    Data.Insert(head, new Disk(fill, -1));
                }
                if (last.Empty)
                {
                    Data.RemoveAt(tail);
                    tail--;
                }
                else if (first.Id == last.Id)
                {
                    head++;
                }

                return (head, tail);
            }

            
        }
        long total = 0;
        int index = 0;
        foreach (var disk in Data)
        {
            if (disk.Id == -1) break;

            var sum = disk.CheckSum(index);
            index += disk.Size;
            total += sum;
        }

        return total;
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

    public long CheckSum(int startIndex)
    {
        long total = 0;
        for (int i = startIndex; i < startIndex + Size; ++i)
        {
            total += i;
        }
        return Id * total;
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

    public static int FillGap(this Disk gap, Disk disk)
    {
        if (gap.Id == -1)
        {
            var mergeSpace = gap.Size - disk.Size;
            gap.Size = Math.Clamp(disk.Size, 0, gap.Size);
            disk.Size = mergeSpace >= 0 ? 0 : -mergeSpace;
            gap.Id = disk.Id;
            return mergeSpace;
        }

        return gap.Size;
    }

    public static int SwapGap(this Disk gap, Disk disk)
    {
        if (gap.Id == -1)
        {
            var mergeSpace = gap.Size - disk.Size;
            gap.Size = Math.Clamp(disk.Size, 0, gap.Size);
            gap.Id = disk.Id;
            disk.Id = -1;
            return mergeSpace;
        }

        return gap.Size;
    }

    public static bool CanFillGap(this Disk gap, Disk disk)
    {
        if (gap.Id == -1)
        {
            return gap.Size >= disk.Size;
        }

        return false;
    }
}
