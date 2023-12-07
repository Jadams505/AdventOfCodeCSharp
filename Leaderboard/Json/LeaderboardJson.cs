using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal class LeaderboardJson : IElementJson<LeaderboardJson>
    {
        public string OwnerId { get; set; } = "";
        public int Event { get; set; }
        public List<MemberJson> Members { get; set; } = new();

        public static LeaderboardJson Deserialize(JsonElement json)
        {
            LeaderboardJson leaderboardData = new()
            {
                OwnerId = json.GetProperty("owner_id").ToString(),
                Event = int.Parse(json.GetProperty("event").ToString())
            };

            var members = json.GetProperty("members");

            foreach (var member in members.EnumerateObject())
            {
                leaderboardData.Members.Add(MemberJson.Deserialize(member.Value));
            }

            return leaderboardData;
        }

        public void SortedByDeltaDay(int day)
        {
            Members.Sort((first, second) =>
            {
                first.DayLookup.TryGetValue(day, out DayJson? firstDay);
                second.DayLookup.TryGetValue(day, out DayJson? secondDay);

                int delta = firstDay?.CompareDelta(secondDay) ?? (secondDay is null ? 0 : 1);
                int silver = firstDay?.CompareSilver(secondDay) ?? (secondDay is null ? 0 : 1);
                int gold = firstDay?.CompareGold(secondDay) ?? (secondDay is null ? 0 : 1);

                return delta == 0 ? silver == 0 ? gold : silver : delta;
            });
        }
    }
}
