using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days;

internal abstract partial class Day
{
    public virtual int Year { get; } = 2023; 
    public virtual string FilePath => $"Input/{Year}/{GetType().Name.ToLower()}.txt";
    public string SolutionFilePath => $"../../../{FilePath}";

    [GeneratedRegex(@"\d+")]
    public partial Regex Number();

    [GeneratedRegex(@"\w+")]
    public partial Regex Word();

    [GeneratedRegex(@"[a-zA-Z0-9]+")]
    public partial Regex NumberLetter();

    public abstract Regex ParseString { get; }

    public Day()
    {
        var timer = new Stopwatch();
        timer.Start();
        DownloadInput();
        //CopyToBin();
        ConvertData();
        PrintSolution1();
        PrintSolution2();
        timer.Stop();
        Console.WriteLine("Execution Time: " + timer.ElapsedMilliseconds + "ms");
    }

    public abstract void ConvertData();

    public abstract long GetSolution1();

    public abstract long GetSolution2();

    public void PrintSolution1()
    {
        Console.WriteLine("Solution1: " + GetSolution1());
    }

    public void PrintSolution2()
    {
        Console.WriteLine("Solution2: " + GetSolution2());
    }

    public void DownloadInput()
    {
        FileInfo solution = new(SolutionFilePath);
        if (solution.Directory is not null)
            Directory.CreateDirectory(solution.Directory.FullName);
        if(!solution.Exists)
        {
            int day = int.Parse(Regex.Match(this.GetType().Name, @"\d+").Value);
            var downloadTime = new DateTime(Year, 12, day);
            if (DateTime.Now < downloadTime)
            {
                throw new Exception($"Error. It is too early to request data for {downloadTime}");
            }

            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Cookie, $"session={Secret.SessionCookie}");
            client.Headers.Add(HttpRequestHeader.UserAgent, "github.com/Jadams505/AdventOfCodeCSharp"); // header to comply with https://www.reddit.com/r/adventofcode/comments/z9dhtd/please_include_your_contact_info_in_the_useragent/
            

            try
            {
                client.DownloadFile(
                address: $"https://adventofcode.com/{Year}/day/{day}/input",
                fileName: SolutionFilePath);
            }
            catch (Exception ex)
            {
                try
                {
                    File.Delete(SolutionFilePath);
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    Console.WriteLine
                    (
                        $"""
                        Failed to download file with message:
                        {ex.Message}
                        """
                    );
                }
            }
            
        }
    }

    public void CopyToBin()
    {
        FileInfo solution = new(SolutionFilePath);
        FileInfo bin = new(FilePath);

        if (!solution.Exists)
            return;

        if(!bin.Exists || solution.LastWriteTime.Ticks > bin.LastWriteTime.Ticks)
        {
            File.Copy(solution.FullName, bin.FullName, overwrite: true);
        }
    }
}