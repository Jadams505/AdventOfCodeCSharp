namespace AdventOfCode.Leaderboard;

internal class Runner
{
    public static void Main(string[] args)
    {
        int year = 2024;
        Leaderboard jet = new(Secret.JetLeaderboard, year);
        Leaderboard dad = new(Secret.DadLeaderboard, year);
        Leaderboard combined = jet.CombineMembers(dad);
        LeaderboardTable table = new(combined);
        string outputFile = $"Leaderboard_{year}.txt";

        Console.WriteLine(table);
        table.WriteToFile(outputFile);
    }
}
