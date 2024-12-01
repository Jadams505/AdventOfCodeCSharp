using Clawfoot.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode.Days
{
    internal class Day16 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public MirrorMaze MirrorMaze { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            for(int i = 0; i < contents.Length; ++i)
            {
                var line = contents[i];

                MirrorMaze.Maze.Add(line);
            }
        }

        public override long GetSolution1()
        {
            long result = 0;
            Point start = new(0, 0);
            Point curr = new(0, 0);
            Direction d = Direction.Right;
            MirrorMaze.Energized.Add(start);
            MirrorMaze.Travel(start, curr, d);

            return MirrorMaze.Energized.Count;
        }

        public override long GetSolution2()
        {
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();
            long result = 0;

            Point start;
            Direction d;

            // left column
            for(int i = 1; i < MirrorMaze.Maze.Count - 1; ++i)
            {
                start = new(i, 0);
                d = Direction.Right;
                MirrorMaze.Travel(start, start, d);
                result = Math.Max(result, MirrorMaze.Energized.Count);
                MirrorMaze.Energized.Clear();
                MirrorMaze.Trail.Clear();
            }

            // right column
            for (int i = 1; i < MirrorMaze.Maze.Count - 1; ++i)
            {
                start = new(i, MirrorMaze.Maze[0].Length - 1);
                d = Direction.Left;
                MirrorMaze.Travel(start, start, d);
                result = Math.Max(result, MirrorMaze.Energized.Count);
                MirrorMaze.Energized.Clear();
                MirrorMaze.Trail.Clear();
            }

            // top row
            for (int i = 1; i < MirrorMaze.Maze[0].Length - 1; ++i)
            {
                start = new(0, i);
                d = Direction.Down;
                MirrorMaze.Travel(start, start, d);
                result = Math.Max(result, MirrorMaze.Energized.Count);
                MirrorMaze.Energized.Clear();
                MirrorMaze.Trail.Clear();
            }

            // bottom row
            for (int i = 1; i < MirrorMaze.Maze[0].Length - 1; ++i)
            {
                start = new(MirrorMaze.Maze.Count - 1, i);
                d = Direction.Up;
                MirrorMaze.Travel(start, start, d);
                result = Math.Max(result, MirrorMaze.Energized.Count);
                MirrorMaze.Energized.Clear();
                MirrorMaze.Trail.Clear();
            }

            start = new(0, 0);
            d = Direction.Right;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();

            start = new(0, 0);
            d = Direction.Down;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();

            start = new(0, MirrorMaze.Maze[0].Length - 1);
            d = Direction.Left;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();

            start = new(0, MirrorMaze.Maze[0].Length - 1);
            d = Direction.Right;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();

            start = new(MirrorMaze.Maze.Count - 1, 0);
            d = Direction.Up;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();

            start = new(MirrorMaze.Maze.Count - 1, 0);
            d = Direction.Right;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();


            start = new(MirrorMaze.Maze.Count - 1, MirrorMaze.Maze[0].Length - 1);
            d = Direction.Up;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();

            start = new(MirrorMaze.Maze.Count - 1, MirrorMaze.Maze[0].Length - 1);
            d = Direction.Left;
            MirrorMaze.Travel(start, start, d);
            result = Math.Max(result, MirrorMaze.Energized.Count);
            MirrorMaze.Energized.Clear();
            MirrorMaze.Trail.Clear();

            return result;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class MirrorMaze
    {
        public List<string> Maze { get; set; } = new();

        public HashSet<Point> Energized { get; set; } = new();

        public HashSet<(Direction from, Point curr)> Trail { get; set; } = new();

        public Point Up(Point pos) => new (pos.X - 1, pos.Y);
        public Point Down(Point pos) => new(pos.X + 1, pos.Y);
        public Point Left(Point pos) => new(pos.X, pos.Y - 1);
        public Point Right(Point pos) => new (pos.X, pos.Y + 1);

        public bool ValidPoint(Point pos)
        {
            if (pos.X < 0 || pos.X >= Maze.Count)
                return false;
            if (pos.Y < 0 || pos.Y >= Maze[pos.X].Length)
                return false;

            return true;
        }

        public Point NextPosition(Point position, Direction direction) => direction switch
        {
            Direction.Up => Up(position),
            Direction.Down => Down(position),
            Direction.Left => Left(position),
            Direction.Right => Right(position),
            _ => throw new NotImplementedException()
        };

        public bool Travel(Point position, Direction direction, out List<(Point start, Point nextPos, Direction nextDir)> nextPoints)
        {
            nextPoints = new();
            if (!ValidPoint(position))
                return false;

            if (Trail.Contains((direction, position)))
                return false;
            
            Energized.Add(position);
            Trail.Add((direction, position));

            Point next = NextPosition(position, direction);
            if (!ValidPoint(next))
                return false;

            char encountered = Maze[next.X][next.Y];

            if(encountered == '/')
            {
                direction = direction switch
                {
                    Direction.Up => Direction.Right,
                    Direction.Down => Direction.Left,
                    Direction.Left => Direction.Down,
                    Direction.Right => Direction.Up,
                    _ => throw new Exception("bruh")
                };
            }
            else if(encountered == '\\')
            {
                direction = direction switch
                {
                    Direction.Up => Direction.Left,
                    Direction.Down => Direction.Right,
                    Direction.Left => Direction.Up,
                    Direction.Right => Direction.Down,
                    _ => throw new Exception("bruh")
                };
            }
            else if(encountered == '|')
            {
                if(direction == Direction.Left || direction == Direction.Right)
                {
                    nextPoints.Add((position, next, Direction.Up));
                    nextPoints.Add((position, next, Direction.Down));
                    Energized.Add(next);
                    Trail.Add((direction, next));
                    return true;
                }
            }
            else if(encountered == '-')
            {
                if (direction == Direction.Up || direction == Direction.Down)
                {
                    nextPoints.Add((position, next, Direction.Left));
                    nextPoints.Add((position, next, Direction.Right));
                    Energized.Add(next);
                    Trail.Add((direction, next));
                    return true;
                }
            }

            nextPoints.Add((position, next, direction));
            return true;
        }

        public bool Travel(Point startingPosition, Point currPosition, Direction currDirection)
        {
            bool travel = Travel(currPosition, currDirection, out var next);

            if (travel)
            {
                for(int i = 0; i < next.Count; ++i)
                {
                    var curr = next[i];
                    Travel(curr.start, curr.nextPos, curr.nextDir);
                }
            }
            return travel;
        }
    }
}
