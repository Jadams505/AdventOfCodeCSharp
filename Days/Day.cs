using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    internal abstract class Day
    {
        public virtual string FilePath => $"Input/{GetType().Name.ToLower()}.txt";

        public abstract Regex ParseString { get; }

        public Day()
        {
            var timer = new Stopwatch();
            timer.Start();
            ConvertData();
            PrintSolution1();
            PrintSolution2();
            timer.Stop();
            Console.WriteLine("Execution Time: " + timer.ElapsedMilliseconds + "ms");
        }

        public abstract void ConvertData();

        public abstract long GetSolution1();

        public abstract long GetSolution2();

        public void PrintSolution1()
        {
            Console.WriteLine("Solution1: " + GetSolution1());
        }

        public void PrintSolution2()
        {
            Console.WriteLine("Solution2: " + GetSolution2());
        }
    }
}