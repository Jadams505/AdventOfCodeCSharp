namespace AdventOfCode.Leaderboard
{
    internal class Runner
    {
        public static void Main(string[] args)
        {
            Leaderboard jet = new(Secret.JetLeaderboard, 2023);
            Leaderboard dad = new(Secret.DadLeaderboard, 2023);
            Leaderboard combined = jet.CombineMembers(dad);
            LeaderboardTable table = new(combined);
            string outputFile = "Leaderboard.txt";

            Console.WriteLine(table);
            table.WriteToFile(outputFile);
        }
    }
}
