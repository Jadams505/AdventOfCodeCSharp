using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day3 : Day
	{
		public override string FilePath => "Input/day3.txt";

		public override Regex ParseString => new Regex(@"[a-zA-Z]");

		public List<Rucksack> Sacks { get; set; } = new List<Rucksack>();

		public List<Group> Groups { get; set; } = new List<Group>();

		public Day3() : base() { }

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			foreach (var line in contents)
			{
				Sacks.Add(new Rucksack(line));
			}

			
			for(int i = 0; i < contents.Length; i += 3)
			{
				string[] group = new string[3];
				for(int j = 0; j < 3; ++j)
				{
					group[j] = contents[i + j];
				}
				Groups.Add(new Group(group));
			}
			
		}

		public override long GetSolution1()
		{
			return Sacks.Sum(value => value.ToValue(value.FindCommonChar()));
		}

		public override long GetSolution2()
		{
			return Groups.Sum(value => value.ToValue(value.FindCommonChar()));
		}
	}

	internal class Rucksack
	{
		public string Compartment1 { get; set; }

		public string Compartment2 { get; set;}

		public Rucksack(string rucksack)
		{
			Compartment1 = rucksack.Substring(0, rucksack.Length / 2);
			Compartment2 = rucksack.Substring(rucksack.Length / 2);
		}

		public char FindCommonChar()
		{
			foreach(char c in Compartment1)
			{
				foreach(char c2 in Compartment2)
				{
					if(c == c2)
					{
						return c;
					}
				}
			}
			throw new FormatException("Failed to find common char");
		}

		public int ToValue(char c)
		{
			if (char.IsLower(c))
			{
				return c - 96;
			}
			return c - 38;
		}
	}

	internal class Group
	{
		public string Runsack1 { get; set; }

		public string Runsack2 { get; set; }

		public string Runsack3 { get; set; }

		public Group(string[] runsacks)
		{
			Runsack1 = runsacks[0];
			Runsack2 = runsacks[1];
			Runsack3 = runsacks[2];
		}

		public char FindCommonChar()
		{
			foreach (char c in Runsack1)
			{
				foreach (char c2 in Runsack2)
				{
					foreach (char c3 in Runsack3)
					{
						if (c == c2 && c2 == c3) 
						{ 
							return c;
						}
					}
				}
			}
			throw new FormatException("Failed to find common char");
		}

		public int ToValue(char c)
		{
			if (char.IsLower(c))
			{
				return c - 96;
			}
			return c - 38;
		}
	}
}
