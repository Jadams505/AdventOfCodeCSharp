using AdventOfCode.Leaderboard.Json;
using System.Drawing;
using System.Net;
using System.Text.Json;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Models;
using BetterConsoles.Tables.Configuration;

namespace AdventOfCode.Leaderboard
{
    internal record Leaderboard(string LeaderboardId, int Year)
    {
        public const string EmptyTableEntry = "-";
        public LeaderboardJson Stats { get; private set; } = new();
        public string LeaderboardFile => $"{LeaderboardId}.json";
        public DateTime LastUpdateTimeUtc { get; private set; }

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

        public void PrintPerDayStats()
        {
            if (Stats is null)
                throw new Exception("Operation not allowed call Parse() first");

            for(int i = 1; i <= 25; ++i)
            {
                List<(MemberJson who, long time)> silver = new(Stats.Members.Count);
                List<(MemberJson who, long time)> gold = new(Stats.Members.Count);
                foreach (MemberJson member in Stats.Members)
                {
                    if (member.DayLookup.TryGetValue(i, out var day))
                    {
                        silver.Add((member, day.SilverStar is null ? long.MaxValue : day.SilverStar.StarTimeStamp));
                        gold.Add((member, day.GoldStar is null ? long.MaxValue : day.GoldStar.StarTimeStamp));
                    }
                    else
                    {
                        silver.Add((member, long.MaxValue));
                        gold.Add((member, long.MaxValue));
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
                DateTime dayStart = DayStart(i);

                Console.WriteLine($"Day {i}:\n");

                Console.WriteLine("Silver: ");

                silver.Sort((x, y) => x.time.CompareTo(y.time));
                for (int j = 0; j < silver.Count; ++j)
                {
                    if (silver[j].time != long.MaxValue)
                    {
                        var silverTime = DateTimeOffset.FromUnixTimeSeconds(silver[j].time);
                        TimeSpan deltaTime = silverTime - dayStart;
                        
                        Console.WriteLine($"{silver[j].who.Name} {deltaTime}");

                    }
                    else
                    {
                        Console.WriteLine($"{silver[j].who.Name} not completed");
                    }
                }

                Console.WriteLine("\nGold: ");

                gold.Sort((x, y) => x.time.CompareTo(y.time));
                for (int j = 0; j < gold.Count; ++j)
                {
                    
                    if (gold[j].time != long.MaxValue)
                    {
                        var goldTime = DateTimeOffset.FromUnixTimeSeconds(gold[j].time);
                        TimeSpan deltaTime = goldTime - dayStart;

                        Console.WriteLine($"{gold[j].who.Name} {deltaTime}");
                    }
                    else
                    {
                        Console.WriteLine($"{gold[j].who.Name} not completed");
                    }
                }

                Console.WriteLine();
            }
        }

        public void DayComparison(int day)
        {
            List<(string name, DayJson day)> list = new();
            foreach (var member in Stats.Members)
            {
                if (member.DayLookup.TryGetValue(day, out var dayData))
                {
                    list.Add((member.Name, dayData));
                }
                else
                {
                    list.Add((member.Name, new()));
                } 
            }

            list.Sort((x, y) => x.day.CompareSilver(y.day));

            foreach (var entry in list)
            {
                Console.Write($"{entry.name} {TimeOfCompletion(entry.day.SilverStar?.TimeOfCompletion())} ");
            }
            Console.WriteLine();
        }

        private static string? TimeOfCompletion(DateTime? date)
        {
            return date is null ? "not completed" : date.ToString();
        }

        public IEnumerable<DayJson> SilverStars(string memberName)
        {
            if(Stats is not null)
            {
                var member = Stats.Members.Find(x => x.Name.Equals(memberName));

                if (member is null)
                    return Enumerable.Empty<DayJson>();
                
                var silver = member.DayLookup.Values.Where(data => data.SilverStar is not null);

                return silver ?? Enumerable.Empty<DayJson>();
            }

            return Enumerable.Empty<DayJson>();
        }

        public DateTime DayStart(int day) => new DateTime(Stats!.Event, 12, day);
    }

    internal class Runner
    {
        public static void Main(string[] args)
        {
            Leaderboard leaderboard = new(Secret.DadLeaderboard, 2023);
            leaderboard.GetLeaderboardFromWeb();
            leaderboard.Parse();

            string outputFile = "Leaderboard.txt";

            File.WriteAllText(outputFile, "");

            for(int i = 1; i <= 6; ++i)
            {
                int day = i;

                Console.WriteLine($"Day {day}");

                var builder = new TableBuilder(TableConfig.UnicodeAlt());

                builder.AddColumn("Name");

                var silverCell = new CellFormat()
                {
                    ForegroundColor = Color.Silver,
                };
                builder.AddColumn("Silver");

                var goldCell = new CellFormat()
                {
                    ForegroundColor = Color.Gold
                };
                builder.AddColumn("Gold");

                builder.AddColumn("Delta");

                var table = builder.Build();

                leaderboard.Stats.SortedByDeltaDay(day);
                foreach (var member in leaderboard.Stats.Members)
                {
                    member.AddDayAsRow(table, day, leaderboard.DayStart(day));
                }

                Console.WriteLine(table.ToString());
                File.AppendAllText(outputFile, $"Day {i}\n");
                File.AppendAllText(outputFile, table.ToString() + "\n");
            }
        }
    }
}
