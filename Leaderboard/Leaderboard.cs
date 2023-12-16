using AdventOfCode.Leaderboard.Json;
using System.Net;
using System.Text.Json;

namespace AdventOfCode.Leaderboard
{
    internal class Leaderboard
    {
        public const string EmptyTableEntry = "-";
        public LeaderboardJson Stats { get; private set; } = new();
        public string LeaderboardFile => $"{LeaderboardId}.json";
        public DateTime LastUpdateTimeUtc { get; private set; }
        public string LeaderboardId { get; set; }
        public int Year { get; set; }

        public Leaderboard(string leaderboardId, int year)
        {
            LeaderboardId = leaderboardId;
            Year = year;
            GetLeaderboardFromWeb();
            Parse();
        }

        public Leaderboard CombineMembers(Leaderboard other)
        {
            Stats.Members = Stats.Members.UnionBy(other.Stats.Members, x => x.Name).ToList();
            return this;
        }

        public void GetLeaderboardFromWeb()
        {
            FileInfo existingFile = new(LeaderboardFile);

            if (existingFile.Exists)
            {
                TimeSpan lastWriteDelta = DateTime.UtcNow - existingFile.LastWriteTimeUtc;
                if (lastWriteDelta.TotalMinutes < 30)
                {
                    LastUpdateTimeUtc = existingFile.LastWriteTimeUtc;
                    return;
                }
            }

            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Cookie, $"session={Secret.SessionCookie}");
            byte[] data = client.DownloadData(
                address: $"https://adventofcode.com/{Year}/leaderboard/private/view/{LeaderboardId}.json");

            LastUpdateTimeUtc = DateTime.UtcNow;
            File.WriteAllBytes(existingFile.FullName, data);
        }

        public void Parse()
        {
            string json = File.ReadAllText(LeaderboardFile);
            JsonDocument doc = JsonDocument.Parse(json);

            Stats = LeaderboardJson.Deserialize(doc.RootElement);
        }

        public int CurrDay()
        {
            var now = DateTime.Now;
            var first = new DateTime(Stats.Event, 12, 1);
            var delta = now - first;
            return (int)Math.Ceiling(delta.TotalDays);
        }

        public DateTime DayStart(int day) => new DateTime(Stats.Event, 12, day);
    }
}
