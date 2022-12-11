using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day11 : Day
	{
		public override string FilePath => "Input/day11.txt";

		public override Regex ParseString => new Regex(@"(Monkey \d+:\n  Starting items: (?:(\d+)(?:, )?)+\n  Operation: new = (new|old|\d+) [*+] (new|old|\d+)\n  Test: divisible by (\d+)\n    If true: throw to monkey (\d+)\n    If false: throw to monkey (\d+)\n?\n?)+");


		public Regex ParseItems = new Regex(@"Starting items: (?:(\d+)(?:, )?)+");

		public Regex ParseOperation = new Regex(@"Operation: new = (new|old|\d+) ([*+]) (new|old|\d+)");

		public Regex ParseTest = new Regex(@"Test: divisible by (\d+)");

		public Regex ParseActions = new Regex(@"If (true|false): throw to monkey (\d+)");

		public List<Monkey> Monkeys { get; set; } = new List<Monkey>();

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			Monkey monkey = null;

			foreach(var line in contents)
			{
				if (ParseItems.IsMatch(line))
				{
					monkey = new Monkey();
					var groups = ParseItems.Match(line).Groups;
					for(int i = 0; i < groups[1].Captures.Count; ++i)
					{
						monkey.Items.Add(int.Parse(groups[1].Captures[i].Value));
					}
				}

				if (ParseOperation.IsMatch(line))
				{
					var groups = ParseOperation.Match(line).Groups;
					monkey.Operation[0] = groups[1].Value;
					monkey.Operation[1] = groups[2].Value;
					monkey.Operation[2] = groups[3].Value;
				}

				if (ParseTest.IsMatch(line))
				{
					var groups = ParseTest.Match(line).Groups;
					monkey.TestDivision = int.Parse(groups[1].Value);
				}

				if (ParseActions.IsMatch(line))
				{
					var groups = ParseActions.Match(line).Groups;
					var amount = int.Parse(groups[2].Value);
					if (groups[1].Value == "true")
					{
						monkey.ThrowIfTrue = amount;
					}
					else
					{
						monkey.ThrowIfFalse = amount;
						Monkeys.Add(monkey);
					}
				}
			}
		}

		public override long GetSolution1()
		{/*
			const int ROUNDS = 20;
			List<int> activity = new List<int>();
			for(int i = 0; i < Monkeys.Count; ++i)
			{
				activity.Add(0);
			}
			for(int round = 0; round < ROUNDS; ++round)
			{
				for(int i = 0; i < Monkeys.Count; ++i)
				{
					Monkey monkey = Monkeys[i];
					for (int j = 0; j < monkey.Items.Count; ++j)
					{
						monkey.PerformOperation(j);
						monkey.ReduceWorry(j);
						monkey.TestResult(j, out int throwTo);
						Monkeys[throwTo].Items.Add(monkey.Items[j]);
						activity[i]++;
					}
					monkey.Items.Clear();
				}
			}
			activity.Sort();
			return activity[^1] * activity[^2];*/
			return 0;
		}

		public override long GetSolution2()
		{
			int divisor = 1;
			Monkeys.ForEach(x => divisor *= x.TestDivision);
			const int ROUNDS = 10000;
			List<long> activity = new List<long>();
			for (int i = 0; i < Monkeys.Count; ++i)
			{
				activity.Add(0);
			}
			for (int round = 0; round < ROUNDS; ++round)
			{
				for (int i = 0; i < Monkeys.Count; ++i)
				{
					Monkey monkey = Monkeys[i];
					for (int j = 0; j < monkey.Items.Count; ++j)
					{
						monkey.PerformOperation(j, divisor);
						monkey.TestResult(j, out int throwTo);
						Monkeys[throwTo].Items.Add(monkey.Items[j]);
						activity[i]++;
					}
					monkey.Items.Clear();
				}
			}
			activity.Sort();
			return activity[^1] * activity[^2];
		}
	}

	internal class Monkey
	{
		public List<long> Items { get; set; }

		public string[] Operation { get; set; }

		public int TestDivision { get; set; }
		
		public int ThrowIfTrue { get; set; }

		public int ThrowIfFalse { get; set; }

		public Monkey()
		{
			Items = new List<long>();
			Operation = new string[3];
			TestDivision = 0;
			ThrowIfTrue = 0;
			ThrowIfFalse = 0;
		}

		public void PerformOperation(int index, int mod)
		{
			long first = 0;
			if (Operation[0] == "old")
			{
				first = Items[index];
			}
			else
			{
				first = int.Parse(Operation[0]);
			}
			long second = 0;
			if (Operation[2] == "old")
			{
				second = Items[index];
			}
			else
			{
				second = int.Parse(Operation[2]);
			}

			if (Operation[1] == "+")
			{
				Items[index] = (first + second) % mod;
			}
			else if (Operation[1] == "*")
			{
				Items[index] = (first * second) % mod;
			}
		}

		public void ReduceWorry(int index)
		{
			Items[index] = Items[index] / 3;
		}

		public void TestResult(int index, out int throwTo)
		{
			if(Items[index] % TestDivision == 0)
			{
				throwTo = ThrowIfTrue;
			}
			else
			{
				throwTo = ThrowIfFalse;
			}
		}
	}
}
