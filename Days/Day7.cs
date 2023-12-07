using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    internal class Day7 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public List<Hand> Hands { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);

            foreach(var line in contents)
            {
                var split = line.Split(" ");

                var curr = new Hand(split[0], int.Parse(split[1]));

                Hands.Add(curr);
            }
        }

        public enum Card
        {
            A = 14,
            K = 13,
            Q = 12,
            J = 11,
            T = 10,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
        }

        public enum Rank
        {
            Five = 10,
            Four = 9,
            Full = 8,
            Three = 7,
            Two = 6,
            One = 5,
            High = 4
        }

        public class Hand
        {
            public Card[] Cards { get; set; } = new Card[5];
            public int Bid { get; set; }
            public Dictionary<Card, int> CardCounts { get; set; } = new();

            public Hand(string hand, int bid)
            {
                Bid = bid;
                Parse(hand);
                GetCardCountDict();
            }

            public void Parse(string hand)
            {
                for(int i = 0; i < 5; ++i)
                {
                    Cards[i] = (hand[i]) switch
                    {
                        'A' => Card.A,
                        'K' => Card.K,
                        'Q' => Card.Q,
                        'J' => Card.J,
                        'T' => Card.T,
                        '2' => Card.Two,
                        '3' => Card.Three,
                        '4' => Card.Four,
                        '5' => Card.Five,
                        '6' => Card.Six,
                        '7' => Card.Seven,
                        '8' => Card.Eight,
                        '9' => Card.Nine,
                    };
                }
            }

            public void GetCardCountDict()
            {
                var values = (Card[])Enum.GetValues(typeof(Card));
                for (int i = 0; i < values.Length; ++i)
                {
                    CardCounts.Add(values[i], 0);
                }
                
                for (int i = 0; i < Cards.Length; ++i)
                {
                    CardCounts[Cards[i]]++;
                }
            }

            public Rank GetRank()
            {
                if (CardCounts.ContainsValue(5))
                    return Rank.Five;

                if (CardCounts.ContainsValue(4))
                    return Rank.Four;

                int pairCount = CardCounts.Values.Where(x => x == 2).Count();

                if (CardCounts.ContainsValue(3))
                {
                    if (pairCount == 1)
                        return Rank.Full;
                    return Rank.Three;
                }

                if (pairCount == 2)
                    return Rank.Two;

                if (pairCount == 1)
                    return Rank.One;

                return Rank.High;
            }

            public Rank IncreaseRank()
            {
                Rank curr = GetRank();
                int jcount = CardCounts[Card.J];
                if (!Cards.Contains(Card.J))
                {
                    return curr;
                }

                if(curr == Rank.Five)
                {
                    return Rank.Five;
                }

                if(curr == Rank.Four)
                {
                    return Rank.Five;
                }

                if (curr == Rank.Three)
                {
                    Card threeCount = CardCounts.First(x => x.Value == 3).Key;
                    Card firstOther = CardCounts.First(x => x.Value != 3).Key;
                    Card secondOther = CardCounts.Last(x => x.Value != 3).Key;

                    // J J J 1 2 => 1 1 1 1 2
                    if (jcount == 3)
                    {
                        return Rank.Four;
                    }

                    // J J 1 1 1
                    if(jcount == 2)
                    {
                        // this is not even possible it would be a full house
                        return Rank.Five;
                    }

                    // J 1 1 1 3 => 1 1 1 1 3
                    if (jcount == 1)
                    {
                        return Rank.Four;
                    }
                }

                // J J J 1 1 => 1 1 1 1 1
                if(curr == Rank.Full)
                {
                    return Rank.Five;
                }

                if(curr == Rank.Two)
                {
                    Card pair1 = CardCounts.First(x => x.Value == 2).Key;
                    Card pair2 = CardCounts.Last(x => x.Value == 2).Key;

                    // J J 1 1 3 => 1 1 1 1 3
                    if(pair1 == Card.J || pair2 == Card.J)
                    {
                        return Rank.Four;
                    }

                    // 2 2 1 1 J => 2 2 2 1 1
                    return Rank.Full;
                }

                // J J 1 2 3 => 1 1 1 2 3
                // 1 1 J 2 3 => 1 1 1 2 3
                if(curr == Rank.One)
                {
                    return Rank.Three;
                }

                // J 1 2 3 4 => 1 1 2 3 4
                return Rank.One;
            }

            public int CompareHighest(Hand other)
            {
                for(int i = 0; i < Cards.Length; ++i)
                {
                    if (Cards[i] < other.Cards[i])
                        return -1;
                    else if (Cards[i] > other.Cards[i])
                        return 1;
                }

                return 0;
            }

            public int CompareHighestPart2(Hand other)
            {
                for (int i = 0; i < Cards.Length; ++i)
                {
                    int mine = (int)Cards[i];
                    int yours = (int)other.Cards[i];

                    if (Cards[i] == Card.J)
                        mine = 1;

                    if (other.Cards[i] == Card.J)
                        yours = 1;

                    if (mine < yours)
                        return -1;
                    else if (mine > yours)
                        return 1;
                }

                return 0;
            }

            public int CompareTo(Hand other)
            {
                Rank mine = GetRank();
                Rank otherR = other.GetRank();

                if (mine == otherR)
                    return CompareHighest(other);

                return mine < otherR ? -1 : 1;
            }

            public int CompareToPart2(Hand other)
            {
                Rank mine = IncreaseRank();
                Rank otherR = other.IncreaseRank();

                if (mine == otherR)
                    return CompareHighestPart2(other);

                return mine < otherR ? -1 : 1;
            }
        }


        public override long GetSolution1()
        {
            long result = 0;
            Hands.Sort((x, y) => x.CompareTo(y));

            for(int i = 0; i < Hands.Count; ++i)
            {
                result += (i + 1) * Hands[i].Bid;
            }
            return result;
        }

        public override long GetSolution2()
        {
            long result = 0;

            Hands.Sort((x, y) => x.CompareToPart2(y));

            for (int i = 0; i < Hands.Count; ++i)
            {
                result += (i + 1) * Hands[i].Bid;
            }

            return result;
        }
    }
}
