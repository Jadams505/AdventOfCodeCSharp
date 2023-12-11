using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Point = (int i, int j);

namespace AdventOfCode.Days
{
    internal class Day10 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public PipeMap Map { get; set; } = new();

        

        public override void ConvertData()
        {

            var contents = File.ReadAllLines(FilePath);

            for(int i = 0; i < contents.Length; ++i)
            {
                var line = contents[i];
                var chars = new List<char>();
                foreach(var c in line)
                {
                    chars.Add(c);
                }
                Map.Data.Add(chars);
            }
        }

        public override long GetSolution1()
        {
            
            long result = 0;
            /*
            var loop = Map.Loop();
            result = loop.Count / 2 + 1;
            */
            
            return result;
        }

        public override long GetSolution2()
        {
            long result = 0;
            
            var spots = Map.SpotsInLoop();
            
           // Map.Debug();

            return spots.Count();
        }
    }

    public class PipeMap
    {
        public List<List<char>> Data = new();

        public static char[] Pipes = ['|', '-', 'L', 'J', '7', 'F'];

        public Point Up(Point pos) => (pos.i - 1, pos.j);
        public Point Down(Point pos) => (pos.i + 1, pos.j);
        public Point Left(Point pos) => (pos.i, pos.j - 1);
        public Point Right(Point pos) => (pos.i, pos.j + 1);

        public void Debug()
        {
            var loop = Loop().ToHashSet();

            for(int i = 0; i < Data.Count; ++i)
            {
                for(int j = 0; j < Data[i].Count; ++j)
                {
                    if(!loop.Contains((i, j)))
                    {
                        if (Data[i][j] != '.')
                            Data[i][j] = 'X';
                    }
                    else
                    {
                        Data[i][j] = '\u25a0';
                    }
                }
            }
            File.Delete("day10-test.txt");
            for (int i = 0; i < Data.Count; ++i)
            {
                var builder = new StringBuilder();
                for (int j = 0; j < Data[i].Count; ++j)
                {
                    builder.Append(Data[i][j]);
                }
                builder.Append('\n');
                File.AppendAllText("day10-test.txt", builder.ToString());
            }
        }

        public bool CanLeft(Point pos)
        {
            char curr = Data[pos.i][pos.j];
            pos.j -= 1;
            if (pos.i < 0 || pos.i >= Data.Count)
                return false;
            if (pos.j < 0 || pos.j >= Data[pos.i].Count)
                return false;
            char next = Data[pos.i][pos.j];

            return curr switch
            {
                '-' or 'J' or '7' => next == '-' || next == 'L' || next == 'F',
                _ => false,
            };
        }

        public bool CanRight(Point pos)
        {
            char curr = Data[pos.i][pos.j];
            pos.j += 1;
            if (pos.i < 0 || pos.i >= Data.Count)
                return false;
            if (pos.j < 0 || pos.j >= Data[pos.i].Count)
                return false;
            char next = Data[pos.i][pos.j];

            return curr switch
            {
                '-' or 'L' or 'F' => next == '-' || next == 'J' || next == '7',
                _ => false,
            };
        }

        public bool CanUp(Point pos)
        {
            char curr = Data[pos.i][pos.j];
            pos.i -= 1;
            if (pos.i < 0 || pos.i >= Data.Count)
                return false;
            if (pos.j < 0 || pos.j >= Data[pos.i].Count)
                return false;
            char next = Data[pos.i][pos.j];

            return curr switch
            {
                '|' or 'L' or 'J' => next == '|' || next == '7' || next == 'F',
                _ => false,
            };
        }

        public bool CanDown(Point pos)
        {
            char curr = Data[pos.i][pos.j];
            pos.i += 1;
            if (pos.i < 0 || pos.i >= Data.Count)
                return false;
            if (pos.j < 0 || pos.j >= Data[pos.i].Count)
                return false;
            char next = Data[pos.i][pos.j];

            return curr switch
            {
                '|' or '7' or 'F' => next == '|' || next == 'L' || next == 'J',
                _ => false,
            };
        }

        public bool Travel(Point last, Point curr, out Point next)
        {
            if(CanLeft(curr) && last.j - curr.j != -1)
            {
                next = (curr.i, curr.j - 1);
                return true;
            }

            if(CanRight(curr) && last.j - curr.j != 1)
            {
                next = (curr.i, curr.j + 1);
                return true;
            }

            if(CanUp(curr) && last.i - curr.i != -1)
            {
                next = (curr.i - 1, curr.j);
                return true;
            }

            if(CanDown(curr) && last.i - curr.i != 1)
            {
                next = (curr.i + 1, curr.j);
                return true;
            }
            next = curr;
            return false;
        }

        public Point FindS()
        {
            for(int i = 0; i < Data.Count; ++i)
            {
                for(int j = 0; j < Data[i].Count; ++j)
                {
                    if (Data[i][j] == 'S')
                        return (i, j);
                }
            }
            return (-1, -1);
        }

        public List<Point> CreatePath(Point curr, Point next)
        {
            List<Point> path = [curr, next];
            Point tempNext = next;
            while (Travel(curr, next, out var outNext))
            {
                curr = next;
                next = outNext;
                path.Add(outNext);
            }
            return path;
        }

        public void Set(Point p, char c) => Data[p.i][p.j] = c;
        public char Get(Point p) => Data[p.i][p.j];

        public List<Point> Loop()
        {
            List<Point> path = new();
            Point s = FindS();
            Point up = Up(s);
            Point down = Down(s);
            Point left = Left(s);
            Point right = Right(s);

            Set(s, '|');
            if (CanUp(s) && CanDown(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Up(s));
                Set(s, '|');
                return path;
            }

            Set(s, '-');
            if (CanLeft(s) && CanRight(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Left(s));
                Set(s, '-');
                return path;
            }

            Set(s, 'L');
            if (CanUp(s) && CanRight(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Right(s));
                Set(s, 'L');
                return path;
            }

            Set(s, 'J');
            if (CanUp(s) && CanLeft(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Left(s));
                Set(s, 'J');
                return path;
            }

            Set(s, '7');
            if (CanDown(s) && CanLeft(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Left(s));
                Set(s, '7');
                return path;
            }

            Set(s, 'F');
            if (CanDown(s) && CanRight(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Right(s));
                Set(s, 'F');
                return path;
            }

            return path;
        }

        public List<Point> SpotsInLoop()
        {
            var spots = new List<Point>();
            var loop = Loop().ToHashSet();

            var top = loop.Min(x => x.i);
            var bottom = loop.Max(x => x.i);
            var left = loop.Min(x => x.j);
            var right = loop.Max(x => x.j);

            HashSet<Point> found = new();

            for(int i = top; i <= bottom; ++i)
            {
                char last = '-';
                bool isIn = false;
                int count = 0;
                for(int j = left - 1; j <= right; ++j)
                {
                    if (j < 0) continue;
                    char curr = Get((i, j));

                    if(loop.Contains((i, j)))
                    {
                        if (curr == '-') continue;

                        if (last == 'L' && curr == '7' ||
                        last == 'F' && curr == 'J' ||
                        curr == '|')
                        {
                            isIn = !isIn;
                        }
                    }

                    if (!loop.Contains((i, j)) && isIn)
                    {
                        found.Add((i, j));
                    }

                    if(loop.Contains((i, j)))
                        last = curr;
                }
            }

            return found.ToList();
        }
    }
}
