using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal partial class Day1 : Day
    {
        public override Regex ParseString => new(@"\w+");

        public List<string> Data { get; set; } = new();

        public override void ConvertData()
        {
            string[] contents = File.ReadAllLines(FilePath);

            foreach (string s in contents)
            {
                var match = ParseString.Match(s);

                if (match.Success)
                    Data.Add(match.Value);
                else
                    Console.WriteLine("FAIL!!!!!!");
            }

        }

        [GeneratedRegex("[1-9]")]
        public partial Regex MatchDigitNumbers();

        [GeneratedRegex("((one|two|three|four|five|six|seven|eight|nine)|([1-9]))")]
        public partial Regex MatchDigitAll();

        public override long GetSolution1()
        {
            long sum = 0;
           
            foreach(string s in Data)
            {
                int num = 0;

                var matches = MatchDigitNumbers().Matches(s);
                Match m1 = matches.First();
                Match m2 = matches.Last();

                num += int.Parse(m1.Value) * 10;
                num += int.Parse(m2.Value);
                sum += num;
            }
            
            return sum;
            
        }

        public override long GetSolution2()
        {
            long sum = 0;
            
            foreach (string s in Data)
            {
                int num = 0;

                var matches = MatchDigitAll().Matches(s);
                Match m1 = matches.First();
                Match m2 = matches.Last();

                num += ParseDigit(m1.Value) * 10;
                num += ParseDigit(m2.Value);
                sum += num;
            }

            return sum;
        }

        public static int ParseDigit(string digit) => digit switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(digit)
        };
    }
}