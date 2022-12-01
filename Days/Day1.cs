using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day1 : Day
    {
        public override string FilePath => "Input/day1.txt";
		public override Regex ParseString => new Regex(@"(\d+\n?)+");
		public List<Elf> Elves { get; set; } = new List<Elf>();

		public Day1() : base() { }

        public override void ConvertData()
        {
			var contents = File.ReadAllLines(FilePath);
			List<int> currData = new List<int>();
			foreach(string line in contents)
			{
				if (line == "")
				{
					Elves.Add(new Elf(currData));
					currData.Clear();
				}
				else
				{
					currData.Add(int.Parse(line));
				}
			}

			if(currData.Count > 0)
			{
				Elves.Add(new Elf(currData));
			}
		}

		public override long GetSolution1()
		{
			int largestSum = 0;
			foreach(Elf elf in Elves)
			{
				int sum = elf.Sum();
				if(sum > largestSum)
				{
					largestSum = sum;
				}
			}
			return largestSum;
		}

		public override long GetSolution2()
		{
			int[] largestSums = { 0, 0, 0};
			largestSums[0] = Elves[0].Sum();
			largestSums[1] = Elves[1].Sum();
			largestSums[2] = Elves[2].Sum();
			Array.Sort(largestSums);
			for(int i = largestSums.Length; i < Elves.Count; ++i)
			{
				int sum = Elves[i].Sum();
				if(sum > largestSums[0])
				{
					largestSums[0] = sum;
					Array.Sort(largestSums);
				}
			}
			return largestSums.Sum();
		}
	}

	internal class Elf
	{
		public int[] Calories { get; set; }

		public Elf(List<int> data)
		{
			Calories = data.ToArray();
		}

		public int Sum()
		{
			int sum = 0;
			foreach(int value in Calories)
			{
				sum += value;
			}
			return sum;
		}
	}
}
