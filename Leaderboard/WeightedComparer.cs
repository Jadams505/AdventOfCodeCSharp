using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Leaderboard
{
    public enum Order
    {
        Before = -1,
        Same = 0,
        After = 1,
    }

    internal class WeightedComparer<T> : IComparer<T>
    {
        
        public (int weight, Comparison<T?> comparison)[] Weighted { get; private set; }

        public WeightedComparer(params (int weight, Comparison<T?> comparer)[] weights)
        {
            Weighted = weights.OrderByDescending(x => x.weight).ToArray();
        }

        public static int Normalize(int num) => Math.Clamp(num, -1, 1); 

        public int Compare(T? x, T? y)
        {
            int currWeight = Weighted[0].weight;
            int score = Normalize(Weighted[0].comparison(x, y));
            for(int i = 1; i < Weighted.Length; ++i)
            {
                int innerWeight = Weighted[i].weight;
                if(currWeight == innerWeight)
                {
                    score += Normalize(Weighted[i].comparison(x, y));
                }
                else if (score != 0)
                {
                    return score;
                }
                currWeight = innerWeight;
            }

            return score;
        }
    }
}
