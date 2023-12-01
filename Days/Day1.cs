using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day1 : Day
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

        public override long GetSolution1()
        {
            long sum = 0;
            int num = 0;
            
            foreach(string s in Data)
            {
                char first = s.First(x => char.IsNumber(x));
                char second = s.Last(x => char.IsNumber(x));
                num += (int)char.GetNumericValue(first) * 10;
                num += (int)char.GetNumericValue(second);
                sum += num;
                num = 0;
            }
            
            return sum;
            
        }

        public override long GetSolution2()
        {
            long sum = 0;
            
            
            foreach (string s in Data)
            {
                int num = 0;
                int firstIndex = 9999999;
                int lastIndex = -1;
                int first = 0;
                int last = 0;
                
                for (int i = 0; i < s.Length; ++i)
                {
                    for (int j = 0; j < validNumber.Length; ++j)
                    {
                        int index = s.IndexOf(validNumber[j]);
                        int index2 = s.LastIndexOf(validNumber[j]);
                        if (index2 != -1 && index2 > lastIndex)
                        {
                            lastIndex = index2;
                            last = j;
                        }

                        if (index != -1 && index < firstIndex)
                        {
                            firstIndex = index;
                            first = j;
                        }
                    }

                    for(int j = 0; j < validDigit.Length; ++j)
                    {
                        int index = s.IndexOf(validDigit[j]);
                        int index2 = s.LastIndexOf(validDigit[j]);
                        if (index2 != -1 && index2 > lastIndex)
                        {
                            lastIndex = index2;
                            last = j;
                        }

                        if (index != -1 && index < firstIndex)
                        {
                            firstIndex = index;
                            first = j;
                        }
                    }
                }

                num += first * 10;
            
                sum += num;
            }

            return sum;
        }

        public static char[] validDigit = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        public static string[] validNumber = new[]
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
        };


    }
}