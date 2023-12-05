using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal class DayJson : IElementJson<DayJson>
    {
        public StarJson? SilverStar { get; set; } = null;
        public StarJson? GoldStar { get; set; } = null;

        public static DayJson Deserialize(JsonElement json)
        {
            DayJson day = new();

            if (json.TryGetProperty("1", out var silver))
                day.SilverStar = StarJson.Deserialize(silver);

            if (json.TryGetProperty("2", out var gold))
                day.GoldStar = StarJson.Deserialize(gold);

            return day;
        }
    }
}
