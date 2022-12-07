using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day7 : Day
	{
		public override string FilePath => "Input/day7.txt";

		public override Regex ParseString => new Regex(@"(?:\$ cd (.+))|(\d+) (.+)");

		public FileItem Root { get; set; }

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			FileItem curr = Root;
			foreach (var line in contents)
			{
				
				if (ParseString.IsMatch(line))
				{
					var match = ParseString.Match(line);

					if (match.Groups[1].Value == "")
					{
						int size = int.Parse(match.Groups[2].Value);
						string file = match.Groups[3].Value;
						FileItem item = new FileItem(file, size, curr);
						curr.Contents.Add(item);
					}
					else
					{
						string folder = match.Groups[1].Value;
						if(Root == null)
						{
							Root = new FileItem(folder, 0, null);
							curr = Root;
						}
						else if(folder == "..")
						{
							curr = curr.Parent;
						}
						else
						{
							FileItem item = new FileItem(folder, 0, curr);
							curr.Contents.Add(item);
							curr = item;

						}
					}
				}
			}
			Root.Size = Sum(Root);
		}

		public override long GetSolution1()
		{
			return SumAtMost100000(Root);
		}

		public int Sum(FileItem item)
		{
			int sum = 0;
			foreach(var element in item.Contents)
			{
				if (element.IsDirectory)
				{
					int innerSum = Sum(element);
					sum += innerSum;
					element.Size = innerSum;
				}
				else
				{
					sum += element.Size;
				}
			}
			return sum;
		}

		public int SumAtMost100000(FileItem item)
		{
			int sum = 0;
			foreach (var element in item.Contents)
			{
				if (element.IsDirectory)
				{
					if (element.Size <= 100000)
					{
						sum += element.Size;
					}
					sum += SumAtMost100000(element);
				}
			}
			return sum;
		}

		public override long GetSolution2()
		{
			const int diskSpace = 70000000;
			const int needed = 30000000;
			int unused = diskSpace - Root.Size;
			int target = needed - unused;

			int winner = int.MaxValue;

			GetDirToDelete(Root, ref winner, target);

			return winner;
		}

		public void GetDirToDelete(FileItem item, ref int currWinner, int target)
		{
			foreach (var element in item.Contents)
			{
				if (element.IsDirectory)
				{
					if (element.Size >= target && element.Size < currWinner)
					{
						currWinner = element.Size;
					}
					GetDirToDelete(element, ref currWinner, target);
				}
			}
		}
	}

	internal class FileItem
	{
		public string Name { get; set; }
		public int Size { get; set; }
		public bool IsDirectory => Contents.Count > 0;
		public FileItem Parent { get; set; }
		public List<FileItem> Contents = new List<FileItem>();

		public FileItem(string name, int size, FileItem parent)
		{
			Name = name;
			Size = size;
			Parent = parent;
		}
	}
}
