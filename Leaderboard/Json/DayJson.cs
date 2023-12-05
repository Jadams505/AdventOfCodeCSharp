using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal class DayJson : IElementJson<DayJson>
    {
        public StarJson SilverStar { get; set; }
        public StarJson GoldStar { get; set; }

        public DayJson(StarJson silverStar, StarJson goldStar)
        {
            SilverStar = silverStar;
            GoldStar = goldStar;
        }

        public static DayJson Deserialize(JsonElement json)
        {
            return new(
                silverStar: StarJson.Deserialize(json.GetProperty("1")), 
                goldStar: StarJson.Deserialize(json.GetProperty("2")));
        }
    }
}
