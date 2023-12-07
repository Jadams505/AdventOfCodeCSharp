using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal class MemberJson : IElementJson<MemberJson>
    {
        public ulong LastStarTimeStamp { get; set; }
        public int GlobalScore { get; set; }
        public int LocalScore { get; set; }
        public string Name { get; set; } = "";
        public Dictionary<int, DayJson> DayLookup { get; set; } = new();

        public static MemberJson Deserialize(JsonElement json)
        {
            MemberJson member = new()
            {
                LastStarTimeStamp = ulong.Parse(json.GetProperty("last_star_ts").ToString()),
                GlobalScore = int.Parse(json.GetProperty("global_score").ToString()),
                LocalScore = int.Parse(json.GetProperty("local_score").ToString()),
                Name = json.GetProperty("name").ToString(),
            };

            var completedDays = json.GetProperty("completion_day_level");

            foreach (var day in completedDays.EnumerateObject())
            {
                member.DayLookup[int.Parse(day.Name)] = DayJson.Deserialize(day.Value);
            }

            return member;
        }
    }
}
