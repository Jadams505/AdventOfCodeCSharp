using AdventOfCode.Leaderboard.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Leaderboard
{
    internal static class Sorting
    {
        private static int DeltaComparer(DayJson? firstDay, DayJson? secondDay) => firstDay?.CompareDelta(secondDay) ?? (secondDay is null ? 0 : 1);
        private static int SilverComparer(DayJson? firstDay, DayJson? secondDay) => firstDay?.CompareSilver(secondDay) ?? (secondDay is null ? 0 : 1);
        private static int GoldComparer(DayJson? firstDay, DayJson? secondDay) => firstDay?.CompareGold(secondDay) ?? (secondDay is null ? 0 : 1);
        
        public static void SortByDeltaTime(this List<MemberJson> members, int day)
        {
            WeightedComparer<DayJson> weightedComparer = new(
                (3, DeltaComparer),
                (2, SilverComparer),
                (1, GoldComparer));

            members.Sort((first, second) =>
            {
                first.DayLookup.TryGetValue(day, out DayJson? firstDay);
                second.DayLookup.TryGetValue(day, out DayJson? secondDay);

                return weightedComparer.Compare(firstDay, secondDay);
            });
        }
    }
}
