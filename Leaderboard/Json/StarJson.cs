using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal class StarJson : IElementJson<StarJson>, IComparable<StarJson>
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

        public DateTime TimeOfCompletion() => DateTimeOffset.FromUnixTimeSeconds(StarTimeStamp).LocalDateTime;

        public int CompareTo(StarJson? other)
        {
            if (other is null)
                return -1;

            if (StarTimeStamp == other.StarTimeStamp)
                return StarIndex.CompareTo(other.StarIndex);

            return StarTimeStamp.CompareTo(other.StarTimeStamp);
        }

        public TimeSpan TimeSpanBetween(StarJson other)
        {
            return TimeOfCompletion() - other.TimeOfCompletion();
        }

        public TimeSpan TimeToCompleteFrom(DateTime startTime)
        {
            var endTime = DateTimeOffset.FromUnixTimeSeconds(StarTimeStamp);
            TimeSpan deltaTime = endTime - startTime;
            if (deltaTime.Ticks < 0)
                throw new ArgumentException("start time is less than end time");

            return deltaTime;
        }
    }
}
