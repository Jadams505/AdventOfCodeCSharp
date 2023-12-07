using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    internal class Day7 : Day
    {
        public override Regex ParseString => throw new NotImplementedException();

        public List<Hand> Hands { get; set; } = new();

        public override void ConvertData()
        {
            var contents = File.ReadAllLines(FilePath);
            Regex number = new(@"\d+");
            Regex word = new(@"\w+");

            foreach(var line in contents)
            {
                var split = line.Split(" ");

                var curr = new Hand();
                curr.Parse(split[0]);
                curr.Bid = int.Parse(split[1]);
                curr.GetCardCountDict();

                Hands.Add(curr);
            }
        }

        public enum Card
        {
            A = 14,
            K = 13,
            Q = 12,
            J = 11, // set back to 11 for part 1
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
            public Card[] Cards = new Card[5];
            public int Bid;

            public Hand()
            {
                
            }

            public Hand(string cards)
            {
                Parse(cards);
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

            public Dictionary<Card, int> CardCounts = new();

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

            public static Rank GetRank(Card[] cards)
            {
                int[] counts = new int[15];
                for (int i = 0; i < cards.Length; ++i)
                {
                    int index = (int)cards[i] - 1;
                    counts[index]++;
                }

                if (counts.Contains(5))
                    return Rank.Five;

                if (counts.Contains(4))
                    return Rank.Four;

                List<int> list = counts.ToList();
                int indexOf1 = list.IndexOf(2);

                if (counts.Contains(3))
                {
                    if (indexOf1 != -1)
                        return Rank.Full;
                    return Rank.Three;
                }

                if (indexOf1 != -1)
                {
                    int indexOf2 = list.IndexOf(2, indexOf1 + 1);
                    if (indexOf2 != -1)
                        return Rank.Two;

                    return Rank.One;
                }

                return Rank.High;
            }

            public Rank GetRank()
            {
                return GetRank(Cards);
            }

            public void SetEveryJTo(List<Card> cards, Card set)
            {
                for(int i = 0; i < 5; ++i)
                {
                    if (cards[i] == Card.J)
                        cards[i] = set;
                }
            }

            public Rank IncreaseRank(out List<Card> cards)
            {
                List<Card> newCards = new(Cards);
                Rank curr = GetRank();
                int jcount = CardCounts[Card.J];
                cards = newCards;
                if (!Cards.Contains(Card.J))
                {
                    cards = newCards;
                    return curr;
                }

                if(curr == Rank.Five)
                {
                    SetEveryJTo(newCards, Card.A);
                    cards = newCards;
                    return Rank.Five;
                }

                if(curr == Rank.Four)
                {
                    Card oneCount = newCards.First(x => x != Card.J);
                    Card fourCount = CardCounts.First(x => x.Value == 4).Key;

                    if(fourCount == Card.J)
                    {
                        SetEveryJTo(newCards, oneCount);
                        cards = newCards;
                        return Rank.Five;
                    }
                    else
                    {
                        SetEveryJTo(newCards, fourCount);
                        cards = newCards;
                        return Rank.Five;
                    }
                }

                Card HighestCard(params Card[] cards)
                {
                    Card high = cards[0];
                    for (int i = 1; i < cards.Length; ++i)
                    {
                        if (cards[i] > high)
                            high = cards[i];
                    }

                    return high;
                }

                if (curr == Rank.Three)
                {
                    Card threeCount = CardCounts.First(x => x.Value == 3).Key;
                    Card firstOther = CardCounts.First(x => x.Value != 3).Key;
                    Card secondOther = CardCounts.Last(x => x.Value != 3).Key;

                    if (jcount == 3)
                    {
                        SetEveryJTo(newCards, HighestCard(firstOther, secondOther));
                        cards = newCards;
                        return Rank.Four;
                    }

                    if(jcount == 2)
                    {
                        SetEveryJTo(newCards, threeCount);
                        cards = newCards;
                        return Rank.Five;
                    }

                    if (jcount == 1)
                    {
                        SetEveryJTo(newCards, threeCount);
                        cards = newCards;
                        return Rank.Four;
                    }
                }

                if(curr == Rank.Full)
                {
                    Card twoCount = CardCounts.First(x => x.Value == 2).Key;
                    Card threeCount = CardCounts.First(x => x.Value == 3).Key;

                    if(threeCount == Card.J)
                    {
                        SetEveryJTo(newCards, twoCount);
                        cards = newCards;
                        return Rank.Five;
                    }
                    else
                    {
                        SetEveryJTo(newCards, threeCount);
                        cards = newCards;
                        return Rank.Five;
                    }
                }

                if(curr == Rank.Two)
                {
                    Card pair1 = CardCounts.First(x => x.Value == 2).Key;
                    Card pair2 = CardCounts.Last(x => x.Value == 2).Key;

                    if(pair1 == Card.J)
                    {
                        SetEveryJTo(newCards, pair2);
                        cards = newCards;
                        return Rank.Four;
                    }

                    if(pair2 == Card.J)
                    {
                        SetEveryJTo(newCards, pair1);
                        cards = newCards;
                        return Rank.Four;
                    }

                    SetEveryJTo(newCards, HighestCard(pair1, pair2));
                    cards = newCards;
                    return Rank.Full; // 3 or full 
                }

                if(curr == Rank.One)
                {
                    Card pair1 = CardCounts.First(x => x.Value == 2).Key;
                    List<Card> others = new();
                    for(int i = 0; i < Cards.Length; ++i)
                    {
                        if (newCards[i] != pair1)
                            others.Add(newCards[i]);
                    }

                    if(pair1 == Card.J)
                    {
                        SetEveryJTo(newCards, HighestCard(others.ToArray()));
                        cards = newCards;
                        return Rank.Three;
                    }
                    else
                    {
                        SetEveryJTo(newCards, pair1);
                        cards = newCards;
                        return Rank.Three;
                    }
                }

                List<Card> notJ = new();
                for(int i = 0; i < Cards.Length; ++i)
                {
                    if (Cards[i] != Card.J)
                        notJ.Add(Cards[i]);
                }
                SetEveryJTo(newCards, HighestCard(notJ.ToArray()));
                cards = newCards;
                return Rank.One;
            }

            public Card Highest()
            {
                Card high = Cards[0];

                for(int i = 1; i < Cards.Length; ++i)
                {
                    if (Cards[i] > high)
                        high = Cards[i];
                }

                return high;
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
                var me = Cards;
                Rank mine = GetRank();
                Rank otherR = other.GetRank();

                if (mine == otherR)
                    return CompareHighest(other);

                return mine < otherR ? -1 : 1;
            }

            public int CompareToPart2(Hand other)
            {
                Rank mine = IncreaseRank(out var myIncrease);
                Rank otherR = other.IncreaseRank(out var otherIncrease);

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
