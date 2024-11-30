using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    internal class Day18 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        List<Instruction> Instructions { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            foreach (var line in contents)
            {
                var split = line.Split(' ');
                char d = split[0][0];
                int num = int.Parse(split[1]);
                string color = split[2].Trim('(', ')');
                Instructions.Add(new(d, num, color));
            }
        }

        public override long GetSolution1()
        {

            return 0;
        }

        public override long GetSolution2()
        {

            return 0;
        }
    }

    public record Instruction(char Direction, int Amount, string Color);
}
