using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day12 : Day
	{
		public override string FilePath => "Input/day12.txt";

		public override Regex ParseString => new Regex("[a-zA-Z]");

		public List<List<Node>> HeightMap = new List<List<Node>>();

		public (int i, int j) Start, End;

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			for(int i = 0; i < contents.Length; ++i)
			{
				List<Node> nodes = new List<Node>();
				for (int j = 0; j < contents[i].Length; ++j)
				{
					nodes.Add(new Node(i, j, contents[i][j]));
				}
				HeightMap.Add(nodes);
			}

			const char START = 'S';
			const char END = 'E';
			for (int i = 0; i < HeightMap.Count; ++i)
			{
				for (int j = 0; j < HeightMap[i].Count; ++j)
				{
					if (HeightMap[i][j].Value == START)
					{
						Start.i = i;
						Start.j = j;
					}

					if (HeightMap[i][j].Value == END)
					{
						End.i = i;
						End.j = j;
					}
				}
			}

			HeightMap[Start.i][Start.j].Value = 'a';
			HeightMap[End.i][End.j].Value = 'z';
		}

		public List<List<Node>> Copy(List<List<Node>> toCopy)
		{
			List<List<Node>> copy = new();

			for(int i = 0; i < toCopy.Count; ++i)
			{
				List<Node> nodes = new List<Node>();
				for (int j = 0; j < toCopy[i].Count; ++j)
				{
					var old = toCopy[i][j];
					nodes.Add(new Node(old.i, old.j, old.Value));
				}
				copy.Add(nodes);
			}
			return copy;
		}

		public override long GetSolution1()
		{
			var copy = Copy(HeightMap);
			Node end = AStar();
			HeightMap = copy;
			return end.fscore;
		}
		
		public Node AStar()
		{
			Node node = HeightMap[Start.i][Start.j];
			node.gscore = 0;
			node.HScore(End.i, End.j);
			node.FScore();

			Dictionary<(int i, int j), Node> open = new();
			HashSet<(int i, int j)> closed = new();

			open.Add((node.i, node.j), node);

			while (open.Count > 0)
			{
				Node smallest = null;
				foreach (var e in open)
				{
					if (smallest == null || e.Value.fscore < smallest.fscore)
					{
						smallest = e.Value;
					}
				}

				open.Remove((smallest.i, smallest.j));

				Node left = Left(smallest.i, smallest.j, End.i, End.j);
				Node right = Right(smallest.i, smallest.j, End.i, End.j);
				Node up = Up(smallest.i, smallest.j, End.i, End.j);
				Node down = Down(smallest.i, smallest.j, End.i, End.j);
				List<Node> neighbors = new List<Node>() { left, right, up, down };

				foreach (var n in neighbors)
				{
					if (n == null)
					{
						continue;
					}

					if (n.i == End.i && n.j == End.j)
					{
						return HeightMap[n.i][n.j];
					}

					if (open.TryGetValue((n.i, n.j), out Node dictNode))
					{
						if (dictNode.fscore < n.fscore)
						{
							continue;
						}
						open.Remove((n.i, n.j));
					}

					if (closed.TryGetValue((n.i, n.j), out _))
					{
						continue;
					}

					open.Add((n.i, n.j), n);
				}
				closed.Add((smallest.i, smallest.j));
			}

			throw new Exception("A Star Failed");
		}

		public Node Left(int i, int j, int endX, int endY)
		{
			if(j - 1 < 0) // out of bounds
			{
				return null;
			}
			if (i == endX && j == endY) // found the end
			{
				return HeightMap[i][j];
			}
			if (HeightMap[i][j].Value - HeightMap[i][j - 1].Value >= -1) // can step to the left
			{
				HeightMap[i][j - 1].HScore(endX, endY);
				HeightMap[i][j - 1].GScore(HeightMap[i][j].gscore);
				HeightMap[i][j - 1].FScore();
			}
			else // cant step left
			{
				return null;
			}
			return HeightMap[i][j - 1]; // return the node to the left
		}

		public Node Right(int i, int j, int endX, int endY)
		{
			if (j + 1 >= HeightMap[i].Count) // out of bounds
			{
				return null;
			}
			if (i == endX && j == endY) // found the end
			{
				return HeightMap[i][j];
			}
			if (HeightMap[i][j].Value - HeightMap[i][j + 1].Value >= -1) // can go right
			{
				HeightMap[i][j + 1].HScore(endX, endY);
				HeightMap[i][j + 1].GScore(HeightMap[i][j].gscore);
				HeightMap[i][j + 1].FScore();
			}
			else // cant go right
			{
				return null;
			}
			return HeightMap[i][j + 1]; // return the node to the right
		}

		public Node Down(int i, int j, int endX, int endY)
		{
			if (i + 1 >= HeightMap.Count) // out of bounds
			{
				return null;
			}
			if (i == endX && j == endY) // found the end
			{
				return HeightMap[i][j];
			}
			if (HeightMap[i][j].Value - HeightMap[i + 1][j].Value >= -1) // can go down
			{
				HeightMap[i + 1][j].HScore(endX, endY);
				HeightMap[i + 1][j].GScore(HeightMap[i][j].gscore);
				HeightMap[i + 1][j].FScore();
			}
			else // cant go down
			{
				return null;
			}
			return HeightMap[i + 1][j]; // return the node underneath
		}

		public Node Up(int i, int j, int endX, int endY)
		{
			if (i - 1 < 0) // out of bounds
			{
				return null;
			}
			if (i == endX && j == endY) // found the end
			{
				return HeightMap[i][j];
			}
			if (HeightMap[i][j].Value - HeightMap[i - 1][j].Value >= -1) // can go up
			{
				HeightMap[i - 1][j].HScore(endX, endY);
				HeightMap[i - 1][j].GScore(HeightMap[i][j].gscore);
				HeightMap[i - 1][j].FScore();
			}
			else // cant go up
			{
				return null;
			}
			return HeightMap[i - 1][j]; // return the node above
		}

		// This is really slow
		public override long GetSolution2()
		{
			var copy = Copy(HeightMap);
			int best = int.MaxValue;
			for(int i = 0; i < HeightMap.Count; ++i)
			{
				for(int j = 0; j < HeightMap[i].Count; ++j)
				{
					var start = HeightMap[i][j];
					if (start.Value == 'a')
					{
						Start.i = start.i;
						Start.j = start.j;
						try
						{
							Node end = AStar();
							if (end.fscore < best)
							{
								best = end.fscore;
							}
							HeightMap = Copy(copy);
						}
						catch(Exception)
						{
							continue;
						}
					}
				}
			}
			return best;
		}
	}

	internal class Node
	{
		public int i, j; // position of the node
		public char Value { get; set; }

		public int hscore; // distance from end
		public int gscore; // distance from start
		public int fscore; // hscore + gscore

		const int MAX_VALUE = 999999; // A value too large for the data set so comparisons work

		public Node(int i, int j, char value)
		{
			Value = value;
			hscore = MAX_VALUE;
			gscore = MAX_VALUE;
			fscore = MAX_VALUE;
			this.i = i;
			this.j = j;
		}

		// Unit distance from this node to the target node
		// This does not change
		public void HScore(int endRow, int endCol)
		{
			hscore = Math.Abs(i - endRow) + Math.Abs(j - endCol);
		}

		// Best path found distance from this node to the start
		// This changes as better paths are found
		// Only updates when the adjGScore is smaller
		public void GScore(int adjGScore)
		{
			gscore = Math.Min(adjGScore + 1, gscore);
		}

		// The sum of the hscore and gscore
		// Used for comparisons
		public void FScore()
		{
			fscore = hscore + gscore;
		}
	}
}
