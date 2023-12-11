using System.Drawing;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day11 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public Universe? Universe { get; set; } = null;

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            List<List<char>> data = new();
            for (int i = 0; i < contents.Length; ++i)
            {
                var line = contents[i];
                var chars = new List<char>();
                foreach (var c in line)
                {
                    chars.Add(c);
                }
                data.Add(chars);
            }

            Universe = new(data);
        }

        public override long GetSolution1()
        {
            long result = 0;

            Universe!.Expanse = 2 - 1;

            foreach (var pair in Universe.Pairs)
            {
                result += Universe.ShortestDistance(pair.a, pair.b);
            }

            return result;
        }

        public override long GetSolution2()
        {
            long result = 0;

            Universe!.Expanse = 1_000_000 - 1;

            foreach (var pair in Universe.Pairs)
            {
                result += Universe.ShortestDistance(pair.a, pair.b);
            }
            return result;
        }
    }

    public class Universe
    {
        public List<List<char>> Data { get; set; } = new();

        public List<Point> Galaxies = new List<Point>();
        public List<(Point a, Point b)> Pairs = new();

        private List<int> EmptyRowIndexes = new();

        private List<int> EmptyColIndexes = new();

        public int Expanse { get; set; }

        public Universe(List<List<char>> data)
        {
            Data = data;
            PopulateGalaxies();
            EmptyRowIndexes = EmptyRows();
            EmptyColIndexes = EmptyCols();
            Pairs = GetPairs();
        }

        public long ShortestDistance(Point a, Point b)
        {
            int minX = Math.Min(a.X, b.X);
            int maxX = Math.Max(a.X, b.X);
            int minY = Math.Min(a.Y, b.Y);
            int maxY = Math.Max(a.Y, b.Y);
            int deltaX = b.X - a.X;
            int deltaY = b.Y - a.Y;

            int rows = EmptyRowIndexes.Count(x => x > minX && x < maxX);
            int cols = EmptyColIndexes.Count(x => x > minY && x < maxY);

            long res = Math.Abs(deltaX) + Math.Abs(deltaY) + rows * Expanse + cols * Expanse;

            return res;
        }

        public List<(Point a, Point b)> GetPairs()
        {
            var pairs = new List<(Point, Point)>();
            for(int i = 0; i < Galaxies.Count; ++i)
            {
                for(int j = i + 1; j < Galaxies.Count; ++j)
                {
                    pairs.Add(new(Galaxies[i], Galaxies[j]));
                }
            }
            return pairs;
        }

        public void PopulateGalaxies()
        {
            for(int i = 0; i < Data.Count; ++i)
            {
                for(int j = 0; j < Data[i].Count; ++j)
                {
                    if (Data[i][j] == '#')
                    {
                        Galaxies.Add(new(i, j));
                    }
                }
            }
        }

        public List<int> EmptyRows()
        {
            List<int> emptyRows = new();
            for (int i = 0; i < Data.Count; ++i)
            {
                int index = Data.FindIndex(i, x => !x.Contains('#'));
                if (index != -1)
                {
                    emptyRows.Add(index);
                    i = index;
                }else
                {
                    break;
                }
            }
            return emptyRows;
        }

        public List<int> EmptyCols()
        {
            List<int> emptyCol = new();
            for (int j = 0; j < Data[0].Count; ++j)
            {
                bool hasGal = false;
                for (int i = 0; i < Data.Count; ++i)
                {
                    var curr = Data[i][j];
                    if (curr == '#')
                    {
                        hasGal = true;
                        break;
                    }
                }
                if (!hasGal)
                {
                    emptyCol.Add(j);
                }
            }
            return emptyCol;
        }
    }
}
