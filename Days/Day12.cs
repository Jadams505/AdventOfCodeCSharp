using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace AdventOfCode.Days
{
    internal partial class Day12 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public List<Record> Records { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);


            for(int i = 0; i < contents.Length; ++i)
            {
                var line = contents[i];

                var split = line.Split(' ');

                var recordString = split[0];
                var numbers = split[1];

                var record = new Record();
                foreach(var c in recordString)
                {
                    record.States.Add(Record.CharToState(c));
                }
                

                var numList = numbers.Split(',');
                foreach(var n in numList)
                {
                    record.Alternative.Add(int.Parse(n));
                }
                Records.Add(record);
            }
        }

        public override long GetSolution1()
        {
            long result = 0;

            foreach(var r in Records)
            {
                result += r.ListPermutations(r.Alternative.Count).Count();
            }

            return result;
        }

        public override long GetSolution2()
        {
            long result = 0;

            return result;
        }
    }

    /// <summary>
    /// Operational (.)
    /// Damaged (#)
    /// Unknown (?)
    /// </summary>
    public enum State
    {
        Operational,
        Damaged,
        Unknown
    }

    public partial class Record
    {
        public List<State> States { get; set; } = new();
        public List<int> Alternative { get; set; } = new();

        public static State CharToState(char c) => c switch
        {
            '.' => State.Operational,
            '#' => State.Damaged,
            '?' => State.Unknown,
            _ => throw new Exception("Bruh")
        };

        public static int Permutation(List<State> toTest, List<int> nums)
        {
            int result = 0;
            int sum = nums.Sum();
            int max = toTest.Count - sum - nums.Count + 2;
            for(int i = max; i >= 1; --i)
            {
                for(int j = i; j <= max; ++j)
                {
                    result += i;
                }
            }
            return result;
        }

        public IEnumerable<List<State>> ListPermutations(int n)
        {
            return n switch
            {
                1 => List1Permutations(),
                2 => List2Permutations(),
                3 => List3Permutations(),
                4 => List4Permutations(),
                5 => List5Permutations(),
                6 => List6Permutations(),
                _ => throw new Exception("Help me")
            };
        }

        public bool CheckPermutation(List<State> perm)
        {
            for(int i = 0; i < States.Count; ++i)
            {
                if (States[i] != State.Unknown && States[i] != perm[i])
                    return false;
            }
            return true;
        }

        public static IEnumerable<List<State>> EnumeratePermutations(int num, int length)
        {
            int size = length - num + 1;
            int start = 0;
            int count = 0;
            for (int i = 0; i < size; ++i)
            {
                List<State> curr = new(length);
                for (int j = 0; j < length; ++j)
                {
                    if (count < num && j >= start)
                    {
                        curr.Add(State.Damaged);
                        count++;
                    }
                    else
                    {
                        curr.Add(State.Operational);
                    }
                }
                yield return curr;
                count = 0;
                start++;
            }
        }

        public static List<List<State>> CreatePermutations(int num, int length)
        {
            int size = length - num + 1;
            List<List<State>> perms = new(size);
            int start = 0;
            int count = 0;
            for(int i = 0; i < size; ++i)
            {
                List<State> curr = new(length);
                for(int j = 0; j < length; ++j)
                {
                    if(count < num && j >= start)
                    {
                        curr.Add(State.Damaged);
                        count++;
                    }
                    else
                    {
                        curr.Add(State.Operational);
                    }
                }
                perms.Add(curr);
                count = 0;
                start++;
            }
            return perms;
        }
    }

    public static class Extensions
    {
        public static int FindIndexOfConsecutive<T>(this List<T> list, Predicate<T> match, int start, int n)
        {
            int count = 0;
            int lasti = -1;
            for (int i = start; i < list.Count; ++i)
            {
                T curr = list[i];
                if (match(curr) && (lasti == i - 1 || count == 0))
                {
                    count++;
                    if (count == n)
                        return i - n + 1;
                    lasti = i;
                }
                else
                    count = 0;
            }
            return -1;
        }
    }
}
