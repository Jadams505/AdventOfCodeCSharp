namespace AdventOfCode.Leaderboard
{
    internal class Runner
    {
        public static void Main(string[] args)
        {
            Leaderboard leaderboard = new(Secret.DadLeaderboard, 2023);
            LeaderboardTable table = new(leaderboard);
            string outputFile = "Leaderboard.txt";

            Console.WriteLine(table);
            table.WriteToFile(outputFile);
        }
    }
}
