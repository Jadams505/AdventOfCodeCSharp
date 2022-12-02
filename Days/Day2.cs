using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
	internal class Day2 : Day
	{
		public override string FilePath => "Input/day2.txt";
		public override Regex ParseString => new Regex(@"([ABC]) ([XYZ])");

		public List<Pair> Rounds { get; set; } = new List<Pair>();

		public Day2() : base() { }

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);
			foreach (string line in contents)
			{
				Match match = ParseString.Match(line);
				Rounds.Add(new Pair(match.Groups[1].Value, match.Groups[2].Value));
			}
		}

		public override long GetSolution1()
		{
			return Rounds.Sum(value => value.Score());
		}

		public override long GetSolution2()
		{
			return Rounds.Sum(value => value.ScorePart2());
		}
	}

	internal class Pair
	{
		public const int Rock = 0;
		public const int Paper = 1;
		public const int Scissors = 2;

		public string Opponent { get; set; }
		public string You { get; set; }

		public Pair(string opponent, string you)
		{
			Opponent = opponent;
			You = you;
		}

		public static int ToValue(string choice)
		{
			return choice switch
			{
				"X" or "A" => Rock,
				"Y" or "B" => Paper,
				"Z" or "C" => Scissors,
				_ => throw new ArgumentException("This shouldn't happen")
			};
		}

		public int Score()
		{
			int opp = ToValue(Opponent);
			int you = ToValue(You);

			return Score(opp, you);
		}

		public static int Score(int opp, int you)
		{
			int win = 0;

			if (opp == you)
			{
				win = 3;
			}
			else if ((opp + 1) % 3 == you)
			{
				win = 6;
			}
			else
			{
				win = 0;
			}

			return win + you + 1;
		}

		public int ToValuePart2(int oppValue)
		{
			return You switch
			{
				"X" => (oppValue - 1) < 0 ? Scissors : oppValue - 1,
				"Y" => oppValue,
				"Z" => (oppValue + 1) % 3,
				_ => throw new ArgumentException("This shouldn't happen")
			};
		}

		public int ScorePart2()
		{
			int opp = ToValue(Opponent);
			int you = ToValuePart2(opp);

			return Score(opp, you);
		}
	}
}
