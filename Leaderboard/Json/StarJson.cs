using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal class StarJson : IElementJson<StarJson>
    {
        public int StarIndex { get; set; }
        public long StarTimeStamp { get; set; }

        public static StarJson Deserialize(JsonElement json)
        {
            return new StarJson()
            {
                StarIndex = int.Parse(json.GetProperty("star_index").ToString()),
                StarTimeStamp = long.Parse(json.GetProperty("get_star_ts").ToString()),
            };
        }

        public long TimeToSolve(long startTime)
        {
            return StarTimeStamp - startTime;
        }
    }
}
