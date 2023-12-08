using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day8 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public string Instruction = "";

        public Dictionary<string, (string l, string r)> Lookup = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            Instruction = contents[0];
            
            for(int i = 2; i < contents.Length; ++i)
            {
                var split = contents[i].Split(' ');

                string key = Regex.Match(split[0], @"[A-Z0-9]+").Value;
                string l = Regex.Match(split[2], @"[A-Z0-9]+").Value;
                string r = Regex.Match(split[3], @"[A-Z0-9]+").Value;

                Lookup[key] = (l, r);
            }
        }

        public override long GetSolution1()
        {
            int index = 0;
            long count = 0;
            string key = "AAA";
            while(!key.Equals("ZZZ"))
            {
                char curr = Instruction[index];
                if(curr == 'L')
                {
                    key = Lookup[key].l;
                }
                else if(curr == 'R')
                {
                    key = Lookup[key].r;
                }
                index = (index + 1) % Instruction.Length;
                count++;
            }
            return count;
        }

        public long StepsToEndZ(string key)
        {
            int index = 0;
            long count = 0;
            while (!key.EndsWith("Z"))
            {
                char curr = Instruction[index];
                if (curr == 'L')
                {
                    key = Lookup[key].l;
                }
                else if (curr == 'R')
                {
                    key = Lookup[key].r;
                }
                index = (index + 1) % Instruction.Length;
                count++;
            }

            return count;
        }

        public string Step(string key, int index, long count)
        {
                char curr = Instruction[index];
                if (curr == 'L')
                {
                    key = Lookup[key].l;
                }
                else if (curr == 'R')
                {
                    key = Lookup[key].r;
                }
                

            return key;
        }

        /* LCM: https://en.wikipedia.org/wiki/Least_common_multiple */
        public ulong LeastCommonMultiple(ulong num1, ulong num2)
        {
            return (num1 * num2) / GreatestCommonDivisor(num1, num2);
        }

        public ulong LeastCommonMultiple(params ulong[] nums)
        {
            ulong curr = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                ulong next = nums[i];
                curr = LeastCommonMultiple(curr, next);
            }
            return curr;
        }

        /* GCF using Eulers method: https://en.wikipedia.org/wiki/Euclidean_algorithm */
        public ulong GreatestCommonDivisor(ulong num1, ulong num2)
        {
            while(num2 != 0)
            {
                ulong old = num2;
                num2 = num1 % num2;
                num1 = old;
            }
            return num1;
        }

        public ulong GreatestCommonDivisor(params ulong[] nums)
        {
            ulong curr = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                ulong next = nums[i];
                curr = GreatestCommonDivisor(curr, next);
            }
            return curr;
        }

        public override long GetSolution2()
        {
            ulong result = 0;

            var endWithA = Lookup.Keys.Where(x => x.EndsWith("A"));

            List<ulong> steps = new();
            foreach(var entry in endWithA)
            {
                ulong count = (ulong)StepsToEndZ(entry);
                steps.Add(count);
            }
            steps.Sort();

            result = LeastCommonMultiple(steps.ToArray());

            return (long)result;
        }
    }
}
