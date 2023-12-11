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

            Map.Loop();
        }

        public override long GetSolution1()
        {
            
            long result = 0;

            var loop = Map.LoopPoints;
            result = loop.Count / 2;
            
            return result;
        }

        public override long GetSolution2()
        {
            var spots = Map.EnclosedPoints();

            return spots.Count();
        }
    }

    public class PipeMap
    {
        public List<List<char>> Data = new();

        public List<Point> LoopPoints = new();

        public Point Up(Point pos) => (pos.i - 1, pos.j);
        public Point Down(Point pos) => (pos.i + 1, pos.j);
        public Point Left(Point pos) => (pos.i, pos.j - 1);
        public Point Right(Point pos) => (pos.i, pos.j + 1);

        public bool ValidPoint(Point pos)
        {
            if (pos.i < 0 || pos.i >= Data.Count)
                return false;
            if (pos.j < 0 || pos.j >= Data[pos.i].Count)
                return false;

            return true;
        }

        public bool CanLeft(Point pos)
        {
            char curr = Data[pos.i][pos.j];
            pos.j -= 1;

            if (!ValidPoint(pos))
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

            if (!ValidPoint(pos))
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

            if (!ValidPoint(pos))
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

            if (!ValidPoint(pos))
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
            // if you can go left and you didn't come from the left then move left
            if(CanLeft(curr) && last != Left(curr))
            {
                next = (curr.i, curr.j - 1);
                return true;
            }

            if(CanRight(curr) && last != Right(curr))
            {
                next = (curr.i, curr.j + 1);
                return true;
            }

            if(CanUp(curr) && last != Up(curr))
            {
                next = (curr.i - 1, curr.j);
                return true;
            }

            if(CanDown(curr) && last != Down(curr))
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

        public void Loop()
        {
            if (LoopPoints.Count > 0)
                return;

            List<Point> path = new();
            Point s = FindS();

            // Try various values for s and see if they work
            Set(s, '|');
            if (CanUp(s) && CanDown(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Up(s));
                Set(s, '|');
                LoopPoints = path;
                return;
            }

            Set(s, '-');
            if (CanLeft(s) && CanRight(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Left(s));
                Set(s, '-');
                LoopPoints = path;
                return;
            }

            Set(s, 'L');
            if (CanUp(s) && CanRight(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Right(s));
                Set(s, 'L');
                LoopPoints = path;
                return;
            }

            Set(s, 'J');
            if (CanUp(s) && CanLeft(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Left(s));
                Set(s, 'J');
                LoopPoints = path;
                return;
            }

            Set(s, '7');
            if (CanDown(s) && CanLeft(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Left(s));
                Set(s, '7');
                LoopPoints = path;
                return;
            }

            Set(s, 'F');
            if (CanDown(s) && CanRight(s))
            {
                Set(s, 'S');
                path = CreatePath(s, Right(s));
                Set(s, 'F');
                LoopPoints = path;
                return;
            }
        }

        public List<Point> EnclosedPoints()
        {
            var loop = LoopPoints.ToHashSet();

            // Shorten the range to only those points in the loop 
            var top = loop.Min(x => x.i);
            var bottom = loop.Max(x => x.i);
            var left = loop.Min(x => x.j);
            var right = loop.Max(x => x.j);

            List<Point> found = new();

            for(int i = top; i <= bottom; ++i)
            {
                char last = '-';
                bool isIn = false;
                // left - 1 guarentees that isIn is false
                for(int j = left - 1; j <= right; ++j)
                {
                    // hack to bypass left - 1
                    if (j < 0) continue;

                    char curr = Get((i, j));
                    // if the current point in the line is in the loop
                    if(loop.Contains((i, j)))
                    {
                        // skip '-' since the don't effect what is in or out
                        if (curr == '-') continue;

                        // these combinations switch from in and out state
                        if (last == 'L' && curr == '7' ||
                            last == 'F' && curr == 'J' ||
                            curr == '|')
                        {
                            isIn = !isIn;
                        }

                        last = curr;
                    }
                    else if (isIn)
                    {
                        // if the points is not part of the loop and it is enclosed by the loop add it to the list
                        found.Add((i, j));
                    }
                }
            }

            return found.ToList();
        }
    }
}
