using System.Text.RegularExpressions;
using System.Text.Unicode;
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
            /*
            foreach(var r in Records)
            {
                result += r.ListPermutations(r.Alternative.Count).Count();
            }
            */
            return result;
        }

        public static int[] AlreadyDone()
        {
            var lines = File.ReadAllLines("day12_done.txt");
            return Array.ConvertAll(lines, x => int.Parse(x));
        }

        public List<int> NumsToGo(int[] done)
        {
            List<int> thousand = new();
            for(int i = 0; i < Records.Count; ++i)
            {
                thousand.Add(i);
            }
            return thousand.Except(done).ToList();
        }

        public override long GetSolution2()
        {
            long result = 0;
            List<int> counts = new();
            int start = 0;
            /*
            //List<int> toGo = NumsToGo(AlreadyDone());
            var res = Parallel.For(0, Records.Count, i =>
            {
                //int index = toGo[i];
                int index = i;
                var r = Records[index];
                r.Multiply(2);
                int count = r.ListPermutations(r.Alternative.Count).Count();
                counts.Add(count);
                Console.WriteLine($"{index} {count}");
            });
            */
            
            for(int i = start; i < 20; ++i)
            {
                var r = Records[i];
                r.Multiply(3);
                int count = r.ListPermutations(r.Alternative.Count).Count();
                counts.Add(count);
                Console.WriteLine($"{i} {count}");
            }
            
            File.WriteAllLines("day12_debug.txt", counts.ConvertAll(x => $"{start++} {x}"));
            /*
            foreach (var r in Records)
            {
                r.Multiply(2);
            }

            List<int> counts2 = new();
            
            foreach(var r in Records)
            {
                counts2.Add(r.ListPermutations(r.Alternative.Count).Count());
            }
            
            */
            return counts.Sum();
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

        public void Multiply(int n)
        {
            List<State> oldStates = new(States);
            List<int> oldNum = new(Alternative);
            for(int i = 1; i < n; ++i)
            {
                States.Add(State.Unknown);
                States.AddRange(oldStates);
                Alternative.AddRange(oldNum);
            }
        }

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
                7 => List7Permutations(),
                8 => List8Permutations(),
                9 => List9Permutations(),
                10 => List10Permutations(),
                11 => List11Permutations(),
                12 => List12Permutations(),
                13 => List13Permutations(),
                14 => List14Permutations(),
                15 => List15Permutations(),
                16 => List16Permutations(),
                17 => List17Permutations(),
                18 => List18Permutations(),
                19 => List19Permutations(),
                20 => List20Permutations(),
                21 => List21Permutations(),
                22 => List22Permutations(),
                23 => List23Permutations(),
                24 => List24Permutations(),
                25 => List25Permutations(),
                26 => List26Permutations(),
                27 => List27Permutations(),
                28 => List28Permutations(),
                29 => List29Permutations(),
                30 => List30Permutations(),
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

        public bool ValidRange(List<State> curr, Range toCheck)
        {
            if (toCheck.Start.Value < 0 || toCheck.End.Value >= States.Count) return false;
            for(int i = toCheck.Start.Value; i < toCheck.End.Value; ++i)
            {
                if (States[i] != State.Unknown && States[i] != curr[i - toCheck.Start.Value])
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
