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

        public int CompareSilver(DayJson? other)
        {
            StarJson? otherSilver = other?.SilverStar;

            return SilverStar?.CompareTo(otherSilver) ?? (otherSilver is null ? 0 : 1); 
        }

        public int CompareGold(DayJson? other)
        {
            StarJson? otherGold = other?.GoldStar;

            return GoldStar?.CompareTo(otherGold) ?? (otherGold is null ? 0 : 1);
        }

        public int CompareDelta(DayJson? other)
        {
            TimeSpan thisDelta = TimeBetweenStars() ?? TimeSpan.MaxValue;
            TimeSpan otherDelta = other?.TimeBetweenStars() ?? TimeSpan.MaxValue;

            return thisDelta.CompareTo(otherDelta);
        }

        public string SilverCompletionTimeFrom(DateTime startTime)
        {
            if (SilverStar is null)
                return Leaderboard.EmptyTableEntry;

            return SilverStar.TimeToCompleteFrom(startTime);
;       }

        public string GoldCompletionTimeFrom(DateTime startTime)
        {
            if (GoldStar is null)
                return Leaderboard.EmptyTableEntry;

            return GoldStar.TimeToCompleteFrom(startTime);
        }

        public string GetTimeBetweenStarts()
        {
            TimeSpan? between = TimeBetweenStars();

            if(between is null)
                return Leaderboard.EmptyTableEntry;

            if (between.Value.TotalHours > 24)
                return ">24h";

            return between.Value.ToString();
        }

        public TimeSpan? TimeBetweenStars() => GoldStar?.TimeOfCompletion() - SilverStar?.TimeOfCompletion();
    }
}
