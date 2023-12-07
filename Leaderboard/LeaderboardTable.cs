using AdventOfCode.Leaderboard.Json;
using BetterConsoles.Tables;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using BetterConsoles.Tables.Models;
using System.Drawing;
using System.Text;

namespace AdventOfCode.Leaderboard
{
    internal class LeaderboardTable
    {
        public const string EmptyTableEntry = "-";
        public const string Beyond24hEntry = ">24h";
        public const int MinDay = 1;
        public const int MaxDay = 25;

        private string _toStringCache = "";
        private bool _isCurrent = false;
        private bool IsCurrent 
        { 
            get => _isCurrent; 
            set
            {
                if (!value)
                {
                    _toStringCache = "";
                }
                _isCurrent = value;
            } 
        }
        private readonly Dictionary<int, Table> _tableLookup = new();

        public Leaderboard Leaderboard { get; set; }

        public LeaderboardTable(Leaderboard leaderboard)
        {
            Leaderboard = leaderboard;

            int currDay = Leaderboard.CurrDay();

            for(int day = MinDay; day <= currDay; ++day)
            {
                IsCurrent = false;
                _tableLookup[day] = InitialTable();
                AddTableForDay(day);
            }
        }

        public static string FormatTime(TimeSpan? time)
        {
            if (time is null)
                return EmptyTableEntry;

            if (time.Value.TotalHours > 24)
                return Beyond24hEntry;

            return time.Value.ToString();
        }

        public void WriteToFile(string filePath)
        {
            File.WriteAllText(filePath, ToString());
        }

        public override string ToString()
        {
            if (IsCurrent)
                return _toStringCache;

            StringBuilder builder = new();

            for (int day = MinDay; day <= MaxDay; ++day)
            {
                if (_tableLookup.TryGetValue(day, out var table))
                {
                    builder.Append($"Day {day}\n");
                    builder.Append(table.ToString());
                    builder.Append('\n');
                }
            }

            _toStringCache = builder.ToString();
            IsCurrent = true;

            return _toStringCache;
        }

        private void AddTableForDay(int day)
        {
            Leaderboard.Stats.SortedByDeltaDay(day);

            foreach (var member in Leaderboard.Stats.Members)
            {
                AddRowForDay(member, day);
            }
        }

        private void AddRowForDay(MemberJson member, int day)
        {
            Table table = _tableLookup[day];
            DateTime startTime = Leaderboard.DayStart(day);

            _isCurrent = false;
            if (member.DayLookup.TryGetValue(day, out var dayData))
            {
                table.AddRow(
                    member.Name,
                    FormatTime(dayData.SilverCompletionTimeFrom(startTime)),
                    FormatTime(dayData.GoldCompletionTimeFrom(startTime)),
                    FormatTime(dayData.TimeBetweenStars()));
            }
            else
            {
                table.AddRow(
                    member.Name,
                    EmptyTableEntry,
                    EmptyTableEntry,
                    EmptyTableEntry);
            }
        }

        private static Table InitialTable()
        {
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
            
            return builder.Build();
        }
    }
}
