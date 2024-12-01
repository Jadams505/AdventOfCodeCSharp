using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day3 : Day
    {
        public override Regex ParseString => new Regex(@"^.+$");

        public static List<string> Data { get; set; } = new();

        public override void ConvertData()
        {
            string[] contents = File.ReadAllLines(FilePath);

            foreach (string line in contents)
            {
                Data.Add(line);
            }
        }

        public static bool IsSymbol(char c) => c != '.' && !char.IsLetter(c) && !char.IsDigit(c);

        public static bool AdjacentToSymbol(int x, int y)
        {
            char c = '0';
            for(int i = x - 1; i <= x + 1; ++i)
            {
                if (i < 0 || i >= Data.Count)
                    continue;

                string curr = Data[i];
                for (int j = y - 1; j <= y + 1; ++j)
                {
                    if (j < 0 || j >= curr.Length)
                        continue;

                    c = curr[j];
                    if (IsSymbol(c))
                        return true;
                }
            }
            return false;
        }

        public static bool AdjacentToGear(int x, int y, out (int i, int j) gearLocation)
        {
            char c = '0';
            for (int i = x - 1; i <= x + 1; ++i)
            {
                if (i < 0 || i >= Data.Count)
                    continue;

                string curr = Data[i];
                for (int j = y - 1; j <= y + 1; ++j)
                {
                    if (j < 0 || j >= curr.Length)
                        continue;

                    c = curr[j];
                    if (c == '*')
                    {
                        gearLocation = (i, j);
                        return true;
                    }
                }
            }
            gearLocation = (-1, -1);
            return false;
        }

        public override long GetSolution1()
        {
            long sum = 0;

            for (int i = 0; i < Data.Count; ++i)
            {
                Match nextNum = Regex.Match(Data[i], @"\d+");
                while (nextNum.Success)
                {
                    for (int j = nextNum.Index; j < nextNum.Index + nextNum.Value.Length; ++j)
                    {
                        if (AdjacentToSymbol(i, j))
                        {
                            sum += int.Parse(nextNum.Value);
                            break;
                        }
                    }
                    nextNum = nextNum.NextMatch();
                }
            }

            return sum;
        }

        public Dictionary<(int i, int j), List<int>> GearLookup { get; set; } = new();

        public override long GetSolution2()
        {
            long sum = 0;
            for (int i = 0; i < Data.Count; ++i)
            {
                Match nextNum = Regex.Match(Data[i], @"\d+");
                while (nextNum.Success)
                {
                    for (int j = nextNum.Index; j < nextNum.Index + nextNum.Value.Length; ++j)
                    {
                        if (AdjacentToGear(i, j, out var loc))
                        {
                            if (GearLookup.TryGetValue(loc, out var list))
                            {
                                list.Add(int.Parse(nextNum.Value));
                            }
                            else
                            {
                                GearLookup.Add(loc, new List<int>() { int.Parse(nextNum.Value) });
                            }
                            break;
                        }
                    }
                    nextNum = nextNum.NextMatch();
                }
            }

            foreach(var entry in GearLookup)
            {
                if (entry.Value.Count == 2)
                    sum += entry.Value[0] * entry.Value[1];
            }

            return sum;
        }
    }
}
