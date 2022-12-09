using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day8 : Day
	{
		public override string FilePath => "Input/day8.txt";

		public override Regex ParseString => new Regex(@"\d+");

		List<List<int>> Grid = new List<List<int>>();

		public Day8() : base() { }

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			foreach (var line in contents)
			{
				List<int> ints = new List<int>();
				foreach(char num in line)
				{
					int val = (int)char.GetNumericValue(num);
					ints.Add(val);
				}
				Grid.Add(ints);
			}
		}

		public override long GetSolution1()
		{
			int count = 0;
			for(int i = 0; i < Grid.Count; ++i)
			{
				for(int j = 0; j < Grid[i].Count; ++j)
				{
					int target = Grid[i][j];
					bool upBool = true;
					for(int up = i; up >= 0; --up)
					{
						if(!Up(up, j, target))
						{
							upBool = false;
							break;
						}
					}

					bool downBool = true;
					for (int down = i; down < Grid.Count; ++down)
					{
						if (!Down(down, j, target))
						{
							downBool = false;
							break;
						}
					}

					bool leftBool = true;
					for (int left = j; left >= 0; --left)
					{
						if (!Left(i, left, target))
						{
							leftBool = false;
							break;
						}
					}

					bool rightBool = true;
					for (int right = j; right < Grid[i].Count; ++right)
					{
						if (!Right(i, right, target))
						{
							rightBool = false;
							break;
						}
					}

					if(upBool || downBool || leftBool || rightBool)
					{
						count++;
					}
				}
			}
			return count;
		}

		public bool Up(int i, int j, int target)
		{
			if (i - 1 < 0)
			{
				return true;
			}
			if (target > Grid[i - 1][j])
			{
				return true;
			}
			return false;
		}

		public bool Down(int i, int j, int target)
		{
			if (i + 1 >= Grid.Count)
			{
				return true;
			}
			if (target > Grid[i + 1][j])
			{
				return true;
			}
			return false;
		}

		public bool Left(int i, int j, int target)
		{
			if (j - 1 < 0)
			{
				return true;
			}
			if (target > Grid[i][j - 1])
			{
				return true;
			}
			return false;
		}

		public bool Right(int i, int j, int target)
		{
			if (j + 1 >= Grid[i].Count)
			{
				return true;
			}
			if (target > Grid[i][j + 1])
			{
				return true;
			}
			return false;
		}

		public override long GetSolution2()
		{
			int max = 0;
			for (int i = 0; i < Grid.Count; ++i)
			{
				for (int j = 0; j < Grid[i].Count; ++j)
				{
					int target = Grid[i][j];
					int upCount = 0;
					for (int up = i; up > 0; --up)
					{
						upCount++;
						if (!Up(up, j, target))
						{
							break;
						}
						
					}

					int downCount = 0;
					for (int down = i; down < Grid.Count - 1; ++down)
					{
						downCount++;
						if (!Down(down, j, target))
						{
							break;
						}
						
					}

					int leftCount = 0;
					for (int left = j; left > 0; --left)
					{
						leftCount++;
						if (!Left(i, left, target))
						{
							break;
						}
						
					}

					int rightCount = 0;
					for (int right = j; right < Grid[i].Count - 1; ++right)
					{
						rightCount++;
						if (!Right(i, right, target))
						{
							break;
						}
						
					}

					int score = leftCount * rightCount * upCount * downCount;

					if(score > max)
					{
						max = score;
					}
				}
			}
			return max;
		}
	}
}
