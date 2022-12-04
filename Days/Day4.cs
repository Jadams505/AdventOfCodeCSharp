using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day4 : Day
	{
		public override string FilePath => "Input/day4.txt";

		public override Regex ParseString => new Regex(@"(\d+)-(\d+),(\d+)-(\d+)");

		public List<Section> Sections { get; set; } = new List<Section>();

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			foreach (var line in contents)
			{
				Match match = ParseString.Match(line);
				if (match.Success)
				{
					var groups = match.Groups;
					Sections.Add(new Section(int.Parse(groups[1].Value),
						int.Parse(groups[2].Value),
						int.Parse(groups[3].Value),
						int.Parse(groups[4].Value)));
				}
			}
		}

		public override long GetSolution1()
		{
			return Sections.Sum(value => value.IsRedundant() ? 1 : 0);
		}

		public override long GetSolution2()
		{
			return Sections.Sum(value => value.IsOverlapping() ? 1 : 0);
		}
	}

	internal class Section
	{
		public int p1Min, p1Max, p2Min, p2Max;

		public Section(int min1, int max1, int min2, int max2) 
		{
			p1Min = min1;
			p1Max = max1;
			p2Min = min2;
			p2Max = max2;
		}

		public bool IsRedundant()
		{
			if (p1Min < p2Min || (p1Min == p2Min && p1Max >= p2Max))
			{
				return p2Max <= p1Max && p2Min <= p1Max;
			}

			if(p2Min < p1Min || (p1Min == p2Min && p1Max < p2Max))
			{
				return p1Max <= p2Max && p1Min <= p2Max;
			}
			return false;
		}

		public bool IsOverlapping()
		{
			return (p1Min <= p2Min && p1Max >= p2Min) || 
				(p1Min <= p2Max && p1Max >= p2Max) || 
				(p2Min <= p1Min && p2Max >= p1Min) || 
				(p2Min <= p1Max && p2Max >= p1Max);
		}
	}
}
