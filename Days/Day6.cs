using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day6 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        const int Entrys = 4;

        public int[] Time = new int[Entrys];
        public int[] Dist = new int[Entrys];

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            var match = Regex.Match(contents[0], @"\d+");
            for (int i = 0; i < Entrys; ++i)
            {

                Time[i] = int.Parse(match.Value);
                match = match.NextMatch();
            }

            var match2 = Regex.Match(contents[1], @"\d+");
            for (int i = 0; i < Entrys; ++i)
            {

                Dist[i] = int.Parse(match2.Value);
                match2 = match2.NextMatch();
            }
        }

        public override long GetSolution1()
        {
            long tot = 1;
            for(int i = 0; i < Entrys; ++i)
            {
                int time = Time[i];
                int dist = Dist[i];
                long sum = 0;
                for(int j = 0; j < time; j++)
                {
                    double madeIt = Boat.Distance(j, time);
                    if (madeIt > dist)
                        sum++;
                }
                tot *= sum;
            }
            return tot;
        }

        public override long GetSolution2()
        {
            string time = "";
            string distance = "";
            for(int i = 0; i < Entrys; ++i)
            {
                time += Time[i];
                distance += Dist[i];
            }
            long t = long.Parse(time);
            long d = long.Parse(distance);
            long sum = 0;
            for (int j = 0; j < t; j++)
            {
                double madeIt = Boat.Distance(j, (int)t);
                if (madeIt > d)
                    sum++;
            }


            return sum;
        }
    }

    public static class Boat
    {
        public static double Distance(long n, long total)
        {
            return n * (total - n);
        }
    }
}
