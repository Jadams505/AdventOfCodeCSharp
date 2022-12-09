using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day9 : Day
	{
		public override string FilePath => "Input/day9.txt";

		public override Regex ParseString => new Regex(@"([LURD]) (\d+)");

		public List<Motion> Motions { get; set; } = new List<Motion>();

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);
			foreach(var line in contents)
			{
				var match = ParseString.Match(line);
				Motions.Add(new Motion(char.Parse(match.Groups[1].Value),
					int.Parse(match.Groups[2].Value)));
			}
		}

		public int Simulate()
		{
			HashSet<Point> traveledPoints = new HashSet<Point>();

			Point head = new Point();
			Point tail = new Point();
			traveledPoints.Add(tail);
			foreach (var action in Motions)
			{
				for(int i = 0; i < action.Amount; ++i)
				{
					action.MoveHead(ref head);
					action.Do(ref head, ref tail, false);
					traveledPoints.Add(tail);
				}
			}

			return traveledPoints.Count;
		}

		public override long GetSolution1()
		{
			return Simulate();
		}

		public int SimulatePart2()
		{
			HashSet<Point> traveledPoints = new HashSet<Point>();

			Point[] points = { new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };
			traveledPoints.Add(points[^1]);
			foreach (var action in Motions)
			{
				for (int i = 0; i < action.Amount; ++i)
				{
					action.DoBetter(ref points);
					traveledPoints.Add(points[^1]);
				}
			}

			return traveledPoints.Count;
		}

		public override long GetSolution2()
		{
			return SimulatePart2();
		}
	}

	internal class Motion
	{
		public const char LEFT = 'L';
		public const char RIGHT = 'R';
		public const char DOWN = 'D';
		public const char UP = 'U';
		
		public char Direction { get; set; }

		public int Amount { get; set; }

		public Motion(char direction, int amount)
		{
			Direction = direction;
			Amount = amount;
		}

		public void Do(ref Point head, ref Point tail)
		{
			Do(ref head, ref tail, true);
		}

		public void Do(ref Point head, ref Point tail, bool moveHead)
		{
			if (moveHead)
			{
				MoveHead(ref head);
			}
			switch (Direction)
			{
				case LEFT:
					if (head.X == tail.X - 2)
					{
						tail.X -= 1;
						if (head.Y != tail.Y)
						{
							tail.Y = head.Y;
						}
					}
					break;
				case RIGHT:
					if (head.X == tail.X + 2)
					{
						tail.X += 1;
						if (head.Y != tail.Y)
						{
							tail.Y = head.Y;
						}
					}
					break;
				case DOWN:
					if (head.Y == tail.Y - 2)
					{
						tail.Y -= 1;
						if (head.X != tail.X)
						{
							tail.X = head.X;
						}
					}
					break;
				case UP:
					if (head.Y == tail.Y + 2)
					{
						tail.Y += 1;
						if (head.X != tail.X)
						{
							tail.X = head.X;
						}
					}
					break;
				default:
					throw new ArgumentException("Bad Direction");
			}
		}

		private void DoIgnoreDirection(ref Point head, ref Point tail)
		{
			if (head.X == tail.X - 2)
			{
				tail.X -= 1;
				if (head.Y > tail.Y)
				{
					tail.Y++;
				}
				else if(head.Y < tail.Y)
				{
					tail.Y--;
				}
			}
			else if (head.X == tail.X + 2)
			{
				tail.X += 1;
				if (head.Y > tail.Y)
				{
					tail.Y++;
				}
				else if (head.Y < tail.Y)
				{
					tail.Y--;
				}
			}
			else if (head.Y == tail.Y - 2)
			{
				tail.Y -= 1;
				if (head.X > tail.X)
				{
					tail.X++;
				}
				else if(head.X < tail.X)
				{
					tail.X--;
				}
			}
			else if (head.Y == tail.Y + 2)
			{
				tail.Y += 1;
				if (head.X > tail.X)
				{
					tail.X++;
				}
				else if (head.X < tail.X)
				{
					tail.X--;
				}
			}
		}

		public void MoveHead(ref Point head)
		{
			switch (Direction)
			{
				case UP: head.Y += 1; return;
				case DOWN: head.Y -= 1; return;
				case LEFT : head.X -= 1; return;
				case RIGHT : head.X += 1; return;
			}
		}

		public void DoBetter(ref Point[] points)
		{
			ref Point head = ref points[0];
			ref Point tail = ref points[1];
			MoveHead(ref head);
			for (int i = 0; i < points.Length - 1; ++i)
			{
				head = ref points[i];
				tail = ref points[i + 1];
				DoIgnoreDirection(ref head, ref tail);
			}
		}
	}
}
