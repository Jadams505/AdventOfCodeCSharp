using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day9 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        List<List<long>> Nums = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            foreach(var line in contents)
            {
                List<long> toAdd = new();
                Regex reg = new Regex(@"-?\d+");
                var match = reg.Match(line);
                while (match.Success)
                {
                    toAdd.Add(long.Parse(match.Value));
                    match = match.NextMatch();
                }
                Nums.Add(toAdd);
            }
        }

        public List<long> ExtrapolateNext(List<long> list)
        {
            List<long> ret = new();
            long curr = list[0];
            long diff = 0;
            for(int i = 1; i < list.Count; ++i)
            {
                diff = list[i] - curr;
                curr = list[i];
                ret.Add(diff);
            }

            return ret;
        }

        public List<List<long>> ExtrapolateToZero(List<long> list)
        {
            List<List<long>> all = new();
            all.Add(list);
            var curr = ExtrapolateNext(list);
            while(!curr.All(x => x == 0))
            {
                all.Add(curr);
                curr = ExtrapolateNext(curr);
            }
            all.Add(curr);
            return all;
        }

        public long GetPlaceholder(List<List<long>> lists)
        {
            long placeholder = 0;
            for (int i = lists.Count - 2; i >= 0; --i)
            {
                var temp = lists[i];
                long curr = temp[^1];
                placeholder += curr;
            }

            return placeholder;
        }

        public long GetPlaceholder2(List<List<long>> lists)
        {
            long placeholder = 0;
            for (int i = lists.Count - 2; i >= 0; --i)
            {
                var temp = lists[i];
                long curr = temp[0];
                placeholder = curr - placeholder;
            }

            return placeholder;
        }

        public override long GetSolution1()
        {
            long result = 0;

            foreach(var x in Nums)
            {
                var extrap = ExtrapolateToZero(x);
                result += GetPlaceholder(extrap);
            }

            return result;
        }

        public override long GetSolution2()
        {
            long result = 0;

            foreach (var x in Nums)
            {
                var extrap = ExtrapolateToZero(x);
                result += GetPlaceholder2(extrap);
            }

            return result;
        }
    }
}
