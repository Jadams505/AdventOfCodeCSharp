using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal class StarJson : IElementJson<StarJson>
    {
        public int StarIndex { get; set; }
        public ulong StarTimeStamp { get; set; }

        public static StarJson Deserialize(JsonElement json)
        {
            return new StarJson()
            {
                StarIndex = int.Parse(json.GetProperty("star_index").ToString()),
                StarTimeStamp = ulong.Parse(json.GetProperty("get_star_ts").ToString()),
            };
        }
    }
}
