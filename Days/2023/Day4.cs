using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day4 : Day
    {
        public override Regex ParseString => new Regex(@"^.*$");

        public static List<Card> Cards { get; set; } = new(); 

        public override void ConvertData()
        {
            string[] contents = File.ReadAllLines(FilePath);

            int i = 1;
            foreach (string line in contents)
            {
                var match = Regex.Match(line, @"\d+");
                int bar = line.IndexOf('|');
                match = match.NextMatch();
                Card curr = new Card();
                while(match.Success)
                {
                    curr.Number = i;
                    if (match.Index < bar)
                        curr.First.Add(int.Parse(match.Value));
                    else
                        curr.Second.Add(int.Parse(match.Value));

                    match = match.NextMatch();
                }
                i++;
                Cards.Add(curr);
            }
        }

        public override long GetSolution1()
        {
            long sum = 0;
            foreach(var card in Cards)
            {
                int count = card.Matches().Count();
                if (count == 0)
                    continue;
                sum += (int)Math.Pow(2, count - 1);
            }
            return sum;
        }

        public static Dictionary<int, (int count, bool calculated)> CardNumberToCount { get; set; } = new();

        public override long GetSolution2()
        {
            long cardCount = 0;
            for(int i = Cards.Count - 1; i >= 0; --i)
            {
                var card = Cards[i];
                var won = card.CardsWon();
                int count = 1;

                foreach(int n in won)
                {
                    if (CardNumberToCount.TryGetValue(n, out (int count, bool calcualted) value))
                    {
                        count += value.count;
                    }
                }

                CardNumberToCount[card.Number] = (count, true); 
            }

            foreach(var entry in CardNumberToCount)
            {
                cardCount += entry.Value.count;
            }

            return cardCount;
        }
    }

    internal class Card
    {
        public int Number { get; set; }
        public List<int> First { get; set; } = new();
        public List<int> Second { get; set; } = new();

        public IEnumerable<int> Matches()
        {
            return First.Intersect(Second);
        }

        public IEnumerable<int> CardsWon()
        {
            int count = Matches().Count();

            for(int i = Number + 1; i < Number + 1 + count; ++i)
            {
                yield return i;
            }
        }
    }
}
