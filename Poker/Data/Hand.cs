using Poker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Data
{
    public class Hand : IComparable<Hand>
    {
        public List<PlayingCard> Cards { get; set; }

        public Hand()
        {
            Cards = new List<PlayingCard>();
        }

        public int Score
        {
            get
            {
                var score = 0;

                if (HasStraightFlush)
                {
                    score = 5;
                } else if (HasThreeOfAKind)
                {
                    score = 4;
                } else if (HasStraight)
                {
                    score = 3;
                } else if (HasFlush)
                {
                    score = 2;
                } else if (HasPair)
                {
                    score = 1;
                }
                return score;
            }
        }
        public bool HasCard(Rank rank)
        {
            return Cards.Where(c => c.Rank == rank).Any();
        }


        public bool HasPair
        {
            get
            {
                return HasRankMatch(Cards, 2);
            }
        }

        public bool HasThreeOfAKind
        {
            get
            {
                return HasRankMatch(Cards, 3);
            }
        }

        /// <summary>
        /// Determines if there are any matches based on the rank
        /// </summary>
        /// <param name="cards">List of cards being  grouped</param>
        /// <param name="numberOfMatches">Amount of cards needed to match to count as a valid match</param>
        /// <returns></returns>
        public bool HasRankMatch(List<PlayingCard> cards, int numberOfMatches)
        {
            return cards.GroupBy(c => c.Rank).Where(g => g.Count() == numberOfMatches).Any();
        }

        /// <summary>
        /// Determines if all cards have only one suit
        /// </summary>
        /// <param name="cards"></param>
        /// <returns>True if all cards have only one suit</returns>
        public bool HasFlush
        {
            get
            {
                return Cards.GroupBy(c => c.Suit).Count() == 1;
            }
        }

        public bool HasStraight
        {
            get
            {
                var result = false;
                if(Cards.Count > 0)
                {
                    if (HasCard(Rank.Ace)
                        && HasCard(Rank.Two)
                        && HasCard(Rank.Three))
                    {
                        result = true;
                    }
                    else
                    {
                        var orderedCards = Cards.OrderBy(c => c.Rank).ToList();
                        result = !orderedCards.Where((c, index) => index != orderedCards.Count - 1 && (int)c.Rank + 1 != (int)orderedCards[index + 1].Rank).Any();
                    }
                }

                return result;
            }
        }

        public bool HasStraightFlush
        {
            get
            {
                return HasStraight && HasFlush;
            }
        }

        public int CompareTo(Hand other)
        {
            int score = 0;
            if (Score > other.Score)
            {
                score = 1;
            }
            else if (Score < other.Score)
            {
                score = -1;
            }
            else
            {
                int index = 0;

                var orderedCards = Cards.OrderByDescending(r => r.Rank).ToList();
                var otherOrderedCards = Cards.OrderByDescending(r => r.Rank).ToList();
                while (index < orderedCards.Count() && score == 0)
                {
                    score = orderedCards[index].Rank.CompareTo(otherOrderedCards[index].Rank);
                    index++;
                }
            }

            return score;
        }

    }
}
