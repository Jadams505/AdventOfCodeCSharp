using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day2 : Day
    {
        public override Regex ParseString => new Regex(@"(\d+) (green)|(\d+) (red)|(\d+) (blue)");

        public List<Game> Games { get; set; } = new();

        public override void ConvertData()
        {
            string[] contents = File.ReadAllLines(FilePath);

            foreach (string s in contents)
            {
                var split = s.Split(";");

                Game currGame = new();

                foreach(string config in split)
                {
                    int red = 0, green = 0, blue = 0;
                    Match colorMatch = ParseString.Match(config);
                    while (colorMatch.Success)
                    {
                        if (colorMatch.Groups[1].Success)
                            green = int.Parse(colorMatch.Groups[1].Value);
                        else if (colorMatch.Groups[3].Success)
                            red = int.Parse(colorMatch.Groups[3].Value);
                        else if (colorMatch.Groups[5].Success)
                            blue = int.Parse(colorMatch.Groups[5].Value);

                        colorMatch = colorMatch.NextMatch();
                        
                    }

                    currGame.Configs.Add(new(blue, green, red));
                }

                Games.Add(currGame);
            }
        }

        public const int RedMax = 12;
        public const int GreenMax = 13;
        public const int BlueMax = 14;

        public override long GetSolution1()
        {
            long sum = 0;   
            for(int i = 0; i < Games.Count; ++i)
            {
                Game g = Games[i];
                if (g.TooManyBlue() || g.TooManyRed() || g.TooManyGreen())
                    continue;

                sum += i + 1;
            }
            return sum;
        }

        public override long GetSolution2()
        {
            long sum = 0;
            for (int i = 0; i < Games.Count; ++i)
            {
                Game g = Games[i];

                sum += g.MinBlue() * g.MinRed() * g.MinGreen();
            }
            return sum;
        }
    }

    internal record Configuration(int Blue, int Green, int Red);

    internal class Game
    {
        public int index;
        public List<Configuration> Configs { get; set; } = new();

        public bool TooManyRed() => Configs.Exists(x => x.Red > Day2.RedMax);
        public bool TooManyGreen() => Configs.Exists(x => x.Green > Day2.GreenMax);
        public bool TooManyBlue() => Configs.Exists(x => x.Blue > Day2.BlueMax);

        public int MinRed() => Configs.Max(x => x.Red);
        public int MinGreen() => Configs.Max(x => x.Green);
        public int MinBlue() => Configs.Max(x => x.Blue);
    }
}
