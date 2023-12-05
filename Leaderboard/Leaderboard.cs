using AdventOfCode.Leaderboard.Json;
using System.Net;
using System.Text.Json;

namespace AdventOfCode.Leaderboard
{
    internal record Leaderboard(string LeaderboardId, int Year)
    {
        public LeaderboardJson? Stats { get; private set; } = null;
        public string LeaderboardFile => $"{LeaderboardId}.json";

        public void GetLeaderboardFromWeb()
        {
            FileInfo existingFile = new(LeaderboardFile);
            if (!existingFile.Exists)
            {
                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.Cookie, $"session={Secret.SessionCookie}");
                client.DownloadFile(
                    address: $"https://adventofcode.com/{Year}/leaderboard/private/view/{LeaderboardId}.json",
                    fileName: LeaderboardFile);
            }
        }

        public void Parse()
        {
            string json = File.ReadAllText(LeaderboardFile);
            JsonDocument doc = JsonDocument.Parse(json);

            Stats = LeaderboardJson.Deserialize(doc.RootElement);
        }

        public void PrintPerDayStats()
        {
            if (Stats is null)
                throw new Exception("Operation not allowed call Parse() first");
        }
    }

    internal class Runner
    {
        public static void Main(string[] args)
        {
            Leaderboard leaderboard = new(Secret.JetLeaderboard, 2023);
            leaderboard.GetLeaderboardFromWeb();
            leaderboard.Parse();
        }
    }
}
