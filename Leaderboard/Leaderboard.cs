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

            for(int i = 1; i <= 25; ++i)
            {
                List<(MemberJson who, long? time)> silver = new(Stats.Members.Count);
                List<(MemberJson who, long? time)> gold = new(Stats.Members.Count);
                foreach (MemberJson member in Stats.Members)
                {
                    if (member.DayLookup.TryGetValue(i, out var day))
                    {
                        silver.Add((member, day.SilverStar?.StarTimeStamp));
                        gold.Add((member, day.GoldStar?.StarTimeStamp));
                    }
                    else
                    {
                        silver.Add((member, null));
                        gold.Add((member, null));
                    }
                }

                if(silver.Count == 0 && gold.Count == 0)
                {
                    Console.WriteLine($"No one has completed Day {i}");
                    continue;
                }

                if (DateTime.Now < new DateTime(Stats.Event, 12, i))
                {
                    return;
                }
                var dayStart = DayStart(i).ToLocalTime();

                Console.WriteLine($"Day {i}:\n");

                Console.WriteLine("Silver: ");
                for (int j = 0; j < silver.Count; ++j)
                {
                    if (silver[j].time is not null)
                    {
                        var silverTime = DateTimeOffset.FromUnixTimeSeconds(silver[j].time!.Value).ToLocalTime();
                        
                        Console.WriteLine($"{silver[j].who.Name} {silverTime - dayStart}");

                    }
                    else
                        Console.WriteLine($"{silver[j].who.Name} not completed");
                }

                Console.WriteLine("\nGold: ");
                for (int j = 0; j < gold.Count; ++j)
                {
                    
                    if (gold[j].time is not null)
                        Console.WriteLine($"{gold[j].who.Name} {DateTimeOffset.FromUnixTimeSeconds(gold[j].time!.Value).ToLocalTime()}");
                    else
                        Console.WriteLine($"{gold[j].who.Name} not completed");
                }

                Console.WriteLine();
            }
        }

        public DateTimeOffset DayStart(int day) => new DateTimeOffset(Stats!.Event, 12, day, 0, 0, 0, TimeSpan.Zero);
    }

    internal class Runner
    {
        public static void Main(string[] args)
        {
            Leaderboard leaderboard = new(Secret.JetLeaderboard, 2023);
            leaderboard.GetLeaderboardFromWeb();
            leaderboard.Parse();
            leaderboard.PrintPerDayStats();
        }
    }
}
