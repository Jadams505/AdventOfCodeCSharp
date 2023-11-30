using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
	public enum State
	{
		Unknown,
		Beacon,
		Sensor,
	}

	internal class Day15 : Day
	{
		public override string FilePath => "Input/day15.txt";

		public override Regex ParseString => new Regex(@"Sensor at x=(\d+), y=(\d+): closest beacon is at x=(\d+), y=(\d+)");

		public List<SensorBeaconData> Data { get; set; } = new List<SensorBeaconData>();

		public override void ConvertData()
		{
			var contents = File.ReadAllLines(FilePath);

			foreach (var line in contents)
			{
				var match = ParseString.Match(line);

				if (match.Success)
				{
					var groups = match.Groups;

					Data.Add(new(int.Parse(groups[1].Value), int.Parse(groups[2].Value),
						int.Parse(groups[3].Value), int.Parse(groups[4].Value)));
				}
			}
		}

		public State[,] MakeDataMap()
		{
			int smallestX = int.MaxValue, smallestY = int.MaxValue;
			int biggestX = 0, biggestY = 0;
			foreach(var e in Data)
			{
				if(e.BeaconX < smallestX)
				{
					smallestX = e.BeaconX;
				}
				else if(e.BeaconX > biggestX)
				{
					biggestX = e.BeaconX;
				}
				if (e.BeaconY < smallestY)
				{
					smallestY = e.BeaconY;
				}
				else if (e.BeaconY > biggestY)
				{
					biggestY = e.BeaconY;
				}

				if (e.SensorX < smallestX)
				{
					smallestX = e.SensorX;
				}
				else if (e.SensorX > biggestX)
				{
					biggestX = e.SensorX;
				}
				if (e.SensorY < smallestY)
				{
					smallestY = e.SensorY;
				}
				else if (e.SensorY > biggestY)
				{
					biggestY = e.SensorY;
				}
			}

			int diffX = biggestX - smallestX;
			int diffY = biggestY - smallestY;
			State[,] map = new State[biggestX - smallestX, biggestY - smallestY];

			foreach (var e in Data)
			{
				map[e.BeaconX - smallestX, e.BeaconY - smallestY] = State.Beacon;
				map[e.SensorX - smallestX, e.SensorY - smallestY] = State.Sensor;
			}

			return map;
		}

		public override long GetSolution1()
		{
			State[,] map = MakeDataMap();
			return 0;
		}

		public override long GetSolution2()
		{
			return 0;
		}
	}

	internal class SensorBeaconData
	{
		public int SensorX { get; set; }
		public int SensorY { get; set; }
		public int BeaconX { get; set; }
		public int BeaconY { get; set; }

		public SensorBeaconData(int sensorX, int sensorY, int beaconX, int beaconY)
		{
			SensorX = sensorX;
			SensorY = sensorY;
			BeaconX = beaconX;
			BeaconY = beaconY;
		}
	}
}
