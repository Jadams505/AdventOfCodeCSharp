using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    internal class Day14 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public Dish Data { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            
            for(int i = 0; i < contents.Length; ++i)
            {
                List<char> curr = new();
                var line = contents[i];

                foreach(char c in line)
                {
                    curr.Add(c);
                }
                Data.Data.Add(curr);
            }
        }

        public override long GetSolution1()
        {
            long result = 0;
            
            for(int i = 0; i < Data.Data.Count; ++i)
                Data.SlideUp(Data.Data.Count - 1);
            
            result = Data.Score();
            
            return result;
        }

        public Dictionary<long, List<int>> Lookup = new();

        public override long GetSolution2()
        {
            long result = 0;

            for(int i = 1; i < 1000000000 + 1; ++i)
            {
                Data.Cycle();
                long score = Data.Score();
                if (Lookup.ContainsKey(score))
                {
                    Lookup[score].Add(i);
                }
                else
                {
                    Lookup.Add(score, [i]);
                }
            }
            result = Data.Score();

            return result;
        }

        public class Dish
        {
            public List<List<char>> Data { get; set; } = new();


            public void Cycle()
            {
                for (int i = 0; i < Data.Count; ++i)
                    SlideUp(Data.Count - 1);

                for (int i = 0; i < Data[0].Count; ++i)
                    SlideLeft(Data[0].Count - 1);

                for (int i = 0; i < Data.Count; ++i)
                    SlideDown(0);

                for (int i = 0; i < Data[0].Count; ++i)
                    SlideRight(0);

            }

            public void SlideUp(int row)
            {
                int up = row - 1;
                if (up < 0)
                    return;
                for (int i = 0; i < Data[row].Count; ++i)
                {
                    if (Data[row][i] == 'O' && Data[up][i] != '#' && Data[up][i] != 'O')
                    {
                        Data[up][i] = 'O';
                        Data[row][i] = '.';
                    }
                }
                SlideUp(up);
            }

            public void SlideDown(int row)
            {
                int down = row + 1;
                if (down >= Data.Count)
                    return;
                for (int i = 0; i < Data[row].Count; ++i)
                {
                    if (Data[row][i] == 'O' && Data[down][i] != '#' && Data[down][i] != 'O')
                    {
                        Data[down][i] = 'O';
                        Data[row][i] = '.';
                    }
                }
                SlideDown(down);
            }

            public void SlideLeft(int col)
            {
                int left = col - 1;
                if (left < 0)
                    return;
                for (int i = 0; i < Data.Count; ++i)
                {
                    if (Data[i][col] == 'O' && Data[i][left] != '#' && Data[i][left] != 'O')
                    {
                        Data[i][left] = 'O';
                        Data[i][col] = '.';
                    }
                }
                SlideLeft(left);
            }

            public void SlideRight(int col)
            {
                int right = col + 1;
                if (right >= Data[0].Count)
                    return;
                for (int i = 0; i < Data.Count; ++i)
                {
                    if (Data[i][col] == 'O' && Data[i][right] != '#' && Data[i][right] != 'O')
                    {
                        Data[i][right] = 'O';
                        Data[i][col] = '.';
                    }
                }
                SlideRight(right);
            }


            public long Score()
            {
                long score = 0;
                for(int i = 0; i < Data.Count; ++i)
                {
                    int mult = Data.Count - i;
                    for(int j = 0; j < Data[i].Count; ++j)
                    {
                        if (Data[i][j] == 'O')
                            score += mult;
                    }
                }

                return score;
            }

        }
    }
}
