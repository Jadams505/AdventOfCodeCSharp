using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day14 : Day
	{
		public override string FilePath => "Input/day14.txt";

		public override Regex ParseString => new Regex(@"^(?:(\d+),(\d+)(?: -> )?)*$");

		public List<List<Point>> Rocks { get; set; } = new List<List<Point>>();

		public enum State
		{
			Air,
			Rock,
			Sand
		}

		const int SIZE = 10000; // this should be big enough
		public State[,] Simulation { get; set; } = new State[SIZE, SIZE];

		const int START_ROW = 0, START_COL = 500;

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			foreach(var line in contents)
			{
				var match = ParseString.Match(line);

				var group1 = match.Groups[1];

				var group2 = match.Groups[2];
				List<Point> points = new List<Point>();
				for(int i = 0; i < group1.Captures.Count; ++i)
				{
					points.Add(new Point(int.Parse(group2.Captures[i].Value), 
						int.Parse(group1.Captures[i].Value)));
				}
				Rocks.Add(points);
			}

			FillWithRocks();
		}

		public void FillWithRocks()
		{
			foreach(var points in Rocks)
			{
				for(int i = 0; i < points.Count - 1; ++i)
				{
					var p1 = points[i];
					var p2 = points[i + 1];
					int diffX = Math.Abs(p1.X - p2.X);
					int diffY = Math.Abs(p1.Y - p2.Y);
					for(int x = 0; x <= diffX; ++x)
					{
						Simulation[Math.Min(p1.X, p2.X) + x, p1.Y] = State.Rock;
					}
					for(int y = 0; y <= diffY; ++y)
					{
						Simulation[p1.X, Math.Min(p1.Y, p2.Y) + y] = State.Rock;
					}
				}
			}
		}

		public bool? MoveDown(ref int x, ref int y)
		{
			if (x + 1 >= SIZE)
			{
				return null;
			}

			if (Simulation[x + 1, y] == State.Air)
			{
				x++;
				return true;
			}
			return false;
		}

		public bool? MoveDownLeft(ref int x, ref int y)
		{
			if (x + 1 >= SIZE || y - 1 < 0)
			{
				return null;
			}

			if (Simulation[x + 1, y - 1] == State.Air)
			{
				x++;
				y--;
				return true;
			}
			return false;
		}

		public bool? MoveDownRight(ref int x, ref int y)
		{
			if (x + 1 >= SIZE || y + 1 >= SIZE)
			{
				return null;
			}

			if (Simulation[x + 1, y + 1] == State.Air)
			{
				x++;
				y++;
				return true;
			}
			return false;
		}

		public bool? DropSand(ref int x, ref int y)
		{
			bool? down = MoveDown(ref x, ref y);
			if(down == null)
			{
				return null;
			}
			if (down.Value)
			{
				return true;
			}
			bool? downLeft = MoveDownLeft(ref x, ref y);
			if(downLeft == null)
			{
				return null;
			}
			if (downLeft.Value)
			{
				return true;
			}
			bool? downRight = MoveDownRight(ref x, ref y);
			if(downRight == null)
			{
				return null;
			}
			if (downRight.Value)
			{
				return true;
			}
			return false;
		}

		public override long GetSolution1()
		{
			int sandX = START_ROW, sandY = START_COL;
			int sandCount = 0;
			while (true)
			{
				bool? drop = DropSand(ref sandX, ref sandY);
				if(drop == null)
				{
					break;
				}
				if (!drop.Value)
				{
					Simulation[sandX, sandY] = State.Sand;
					sandCount++;
					sandX = START_ROW;
					sandY = START_COL;
				}
			}
			return sandCount;
		}

		public void AddFloor()
		{
			int highestX = 0;

			foreach(var points in Rocks)
			{
				foreach(var p in points)
				{
					if(p.X > highestX)
					{
						highestX = p.X;
					}
				}
			}

			for(int i = 0; i < SIZE; ++i)
			{
				Simulation[highestX + 2, i] = State.Rock;
			}
		}

		public void Clear()
		{
			for(int i = 0; i < Simulation.GetLength(0); ++i)
			{
				for(int j = 0; j < Simulation.GetLength(1); ++j)
				{
					Simulation[i, j] = State.Air;
				}
			}
		}

		public override long GetSolution2()
		{
			Clear();
			FillWithRocks();
			AddFloor();
			int sandX = START_ROW, sandY = START_COL;
			int sandCount = 0;
			while (true)
			{
				bool? drop = DropSand(ref sandX, ref sandY);
				if (drop == null)
				{
					break;
				}
				
				if (!drop.Value)
				{
					Simulation[sandX, sandY] = State.Sand;
					sandCount++;
					if (sandX == START_ROW && sandY == START_COL)
					{
						break;
					}
					sandX = START_ROW;
					sandY = START_COL;
				}
			}

			return sandCount;
		}
	}
}
