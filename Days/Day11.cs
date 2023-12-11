using System.Drawing;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day11 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public Universe Universe { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            for (int i = 0; i < contents.Length; ++i)
            {
                var line = contents[i];
                var chars = new List<char>();
                foreach (var c in line)
                {
                    chars.Add(c);
                }
                Universe.Data.Add(chars);
            }

            Universe.PopulateGalaxies();
        }

        public override long GetSolution1()
        {
            long result = 0;

            Universe.Expanse = 2 - 1;

            var pairs = Universe.GetPairs();
            var cols = Universe.EmptyCols();
            var rows = Universe.EmptyRows();

            foreach (var pair in pairs)
            {
                result += Universe.ShortestDistance2(pair.a, pair.b, rows, cols);
            }

            return result;
        }

        public override long GetSolution2()
        {
            long result = 0;

            Universe.Expanse = 1_000_000 - 1;

            var pairs = Universe.GetPairs();
            var cols = Universe.EmptyCols();
            var rows = Universe.EmptyRows();

            foreach (var pair in pairs)
            {
                result += Universe.ShortestDistance2(pair.a, pair.b, rows, cols);
            }
            return result;
        }
    }

    public class Universe
    {
        public List<List<char>> Data { get; set; } = new();

        public List<Point> Galaxies = new List<Point>();

        public int Expanse { get; set; }

        public List<char> Empty(int size)
        {
            List<char> empty = new();
            for(int i = 0; i < size; ++i)
            {
                empty.Add('.');
            }
            return empty;
        }

        public Point Up(Point pos) => new (pos.X - 1, pos.Y);
        public Point Down(Point pos) => new (pos.X + 1, pos.Y);
        public Point Left(Point pos) => new (pos.X, pos.Y - 1);
        public Point Right(Point pos) => new (pos.X, pos.Y + 1);

        public int ShortestDistance(Point a, Point b)
        {
            int deltaX = b.X - a.X;
            int deltaY = b.Y - a.Y;

            return Math.Abs(deltaX) + Math.Abs(deltaY);
        }

        public long ShortestDistance2(Point a, Point b, List<int> emptyRow, List<int> emptyCol)
        {
            int minX = Math.Min(a.X, b.X);
            int maxX = Math.Max(a.X, b.X);
            int minY = Math.Min(a.Y, b.Y);
            int maxY = Math.Max(a.Y, b.Y);
            int deltaX = b.X - a.X;
            int deltaY = b.Y - a.Y;

            int rows = emptyRow.Count(x => x > minX && x < maxX);
            int cols = emptyCol.Count(x => x > minY && x < maxY);

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

        public void Expand()
        {
            int doubleRow = Data[0].Count * 2;
            int doubleCol = Data.Count * 2;
            List<int> emptyRows = new();
            for(int i = 0; i < Data.Count; ++i)
            {
                int index = Data.FindIndex(i, x => !x.Contains('#'));
                if(index != -1)
                {
                    Data.Insert(index + 1, Empty(Data[index].Count));
                    i = index + 1;
                }
                else
                {
                    break;
                }
            }

            List<int> emptyCol = new();
            for(int j = 0; j < Data[0].Count; ++j)
            {
                bool hasGal = false;
                for (int i = 0; i < Data.Count; ++i)
                {
                    var curr = Data[i][j];
                    if(curr == '#')
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

            int offset = 1;
            foreach (var entry in emptyCol)
            {
                for(int i = 0; i < Data.Count; ++i)
                {
                    Data[i].Insert(entry + offset, '.');
                    
                }
                offset++;
            }
            
        }
    }
}
