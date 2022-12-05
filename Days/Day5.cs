using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day5 : Day
	{
		public override string FilePath => "Input/day5.txt";

		public override Regex ParseString => new Regex(@"move (\d+) from (\d+) to (\d+)");

		public Regex StackParseString => new Regex(@"(?:[ \[]([ A-Z])[ \]][ \n]?){9}");

		public Stack<string>[] Stacks { get; set; } = new Stack<string>[9];

		public List<Procedure> Procedures { get; set; } = new List<Procedure>();

		public Day5() : base()
		{
		}

		public override void ConvertData()
		{
			for (int i = 0; i < Stacks.Length; ++i)
			{
				Stacks[i] = new();
			}
			var contents = File.ReadAllLines(FilePath);

			List<string>[] stacks = new List<string>[9];

			for(int i = 0; i < stacks.Length; ++i)
			{
				stacks[i] = new();
			}

			foreach(string line in contents)
			{
				if (StackParseString.IsMatch(line))
				{
					var captures = StackParseString.Match(line).Groups[1].Captures;
					for(int i = 0; i < stacks.Length; ++i)
					{
						stacks[i].Add(captures[i].Value);
					}
				}
				else if (ParseString.IsMatch(line))
				{
					var groups = ParseString.Match(line).Groups;
					Procedures.Add(new Procedure(int.Parse(groups[1].Value),
						int.Parse(groups[2].Value),
						int.Parse(groups[3].Value)));
				}
			}

			for(int i = 0; i < stacks.Length; ++i)
			{
				for(int j = stacks[i].Count - 1; j >= 0; --j)
				{
					if(stacks[i][j] != " ")
					{
						Stacks[i].Push(stacks[i][j]);
					}
				}
			}
		}

		public override long GetSolution1()
		{/*
			Procedures.ForEach(value => value.DoProcedure(Stacks));
			string message = "";
			foreach(var stack in Stacks)
			{
				message += stack.Pop();
			}
			Console.WriteLine(message);
			*/
			return 0;
		}

		public override long GetSolution2()
		{
			Procedures.ForEach(value => value.DoProcedurePart2(Stacks));
			string message = "";
			foreach (var stack in Stacks)
			{
				message += stack.Pop();
			}
			Console.WriteLine(message);
			return 0;
		}
	}

	internal class Procedure
	{
		int move;
		int from;
		int to;

		public Procedure(int move, int from, int to)
		{
			this.move = move;
			this.from = from;
			this.to = to;
		}

		public void DoProcedure(Stack<string>[] stacks)
		{
			for(int i = 0; i < move; ++i)
			{
				var crate = stacks[from - 1].Pop();
				stacks[to - 1].Push(crate);
			}
		}

		public void DoProcedurePart2(Stack<string>[] stacks)
		{
			List<string> crates = new List<string>();
			for (int i = 0; i < move; ++i)
			{
				string crate = stacks[from - 1].Pop();
				crates.Add(crate);
			}

			for(int i = crates.Count - 1; i >= 0; --i)
			{
				stacks[to - 1].Push(crates[i]);
			}
		}
	}
}
