using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	internal class Day6 : Day
	{
		public override string FilePath => "Input/day6.txt";

		public override Regex ParseString => new Regex("[a-z]");

		public string Data { get; set; } = "";

		public override void ConvertData()
		{
			Data = File.ReadAllText(FilePath);
		}

		public override long GetSolution1()
		{
			for(int i = 0; i < Data.Length; ++i)
			{
				HashSet<char> chars = new HashSet<char>();
				for(int j = 0; j < 4; ++j)
				{
					char letter = Data[i + j];
					if (chars.Contains(letter))
					{
						break;
					}
					chars.Add(Data[i + j]);
				}
				if(chars.Count == 4)
				{
					return i + 4;
				}
			}
			return 0;
		}

		public override long GetSolution2()
		{
			for (int i = 0; i < Data.Length; ++i)
			{
				HashSet<char> chars = new HashSet<char>();
				for (int j = 0; j < 14; ++j)
				{
					char letter = Data[i + j];
					if (chars.Contains(letter))
					{
						break;
					}
					chars.Add(Data[i + j]);
				}
				if (chars.Count == 14)
				{
					return i + 14;
				}
			}
			return 0;
		}
	}
}
