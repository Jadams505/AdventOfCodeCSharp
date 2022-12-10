using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day10 : Day
	{
		public override string FilePath => "Input/day10.txt";

		public override Regex ParseString => new Regex(@"(noop)|((addx) (-*\d+))");

		public List<Instruction> Instructions { get; set; } = new List<Instruction>();

		public const int WIDTH = 40;
		public const int HEIGHT = 6;

		public static char[,] Display { get; set; } = new char[HEIGHT, WIDTH];

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			foreach(var line in contents)
			{
				var match = ParseString.Match(line);

				if (match.Groups[1].Value == "")
				{
					Instructions.Add(new(match.Groups[3].Value, int.Parse(match.Groups[4].Value)));
				}
				else
				{
					Instructions.Add(new(match.Groups[1].Value, 0));
				}
			}

			for(int i = 0; i < Display.GetLength(0); ++i)
			{
				for(int j = 0; j < Display.GetLength(1); ++j)
				{
					Display[i, j] = '.';
				}
			}
		}

		public override long GetSolution1()
		{
			int x = 1;
			int cycle = 0;
			int sum = 0;
			foreach(var line in Instructions)
			{
				line.Simulate(ref cycle, ref x, out int val);
				if(val > 0)
				{
					sum += val;
				}
			}
			return sum;
		}

		public override long GetSolution2()
		{
			int cycle = 0;
			int x = 1;
			foreach(var line in Instructions)
			{
				line.SimulatePart2(ref cycle, ref x);
			}

			for (int i = 0; i < Display.GetLength(0); ++i)
			{
				for (int j = 0; j < Display.GetLength(1); ++j)
				{
					Console.Write(Display[i, j] + " ");
				}
				Console.WriteLine();
			}
			return 0;
		}
	}

	internal class Instruction
	{
		public string action;

		public int amount;

		public Instruction(string action, int amount)
		{
			this.action = action;
			this.amount = amount;
		}

		public void Simulate(ref int cycleCount, ref int xValue, out int val)
		{
			val = 0;
			if(action == "addx")
			{
				cycleCount++;
				if ((cycleCount - 20) % 40 == 0)
				{
					val = cycleCount * xValue;
				}
				cycleCount++;
				if ((cycleCount - 20) % 40 == 0)
				{
					val = cycleCount * xValue;
					xValue += amount;
					return;
				}
				xValue += amount;
				if ((cycleCount - 20) % 40 == 0)
				{
					val = cycleCount * xValue;
				}
			}
			else
			{
				cycleCount++;
				if ((cycleCount - 20) % 40 == 0)
				{
					val = cycleCount * xValue;
				}
			}
		}

		public void SimulatePart2(ref int cycleCount, ref int xValue)
		{
			const int SIZE = 1;
			int row(int i) => i / Day10.WIDTH;
			int col(int i) => i % Day10.WIDTH;
			if (action == "addx")
			{
				if(xValue >= col(cycleCount) - SIZE && xValue <= col(cycleCount) + SIZE)
				{
					Day10.Display[row(cycleCount), col(cycleCount)] = '#';
				}
				cycleCount++;
				if (xValue >= col(cycleCount) - SIZE && xValue <= col(cycleCount) + SIZE)
				{
					Day10.Display[row(cycleCount), col(cycleCount)] = '#';
				}
				cycleCount++;
				xValue += amount;
			}
			else
			{
				if (xValue >= col(cycleCount) - SIZE && xValue <= col(cycleCount) + SIZE)
				{
					Day10.Display[row(cycleCount), col(cycleCount)] = '#';
				}
				cycleCount++;
			}
		}
	}
}
